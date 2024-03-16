using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core;
using ShineCoder_Helpdesk.Core.Enums;
using ShineCoder_Helpdesk.Core.Helpers;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Infrastructure.Models;
using ShineCoder_Helpdesk.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ShineCoder_Helpdesk.Services.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.AUTHENTICATION_SERVICE_API_PREFIX)]
    [ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IHttpContextProxy _httpContextProxy;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IResponseBuilder _responseBuilder;
        private readonly IAuthService _authService;
        private readonly ILogger _logger;
        private readonly IValidator _customerValidator;

        public AuthenticationController(IAuthService authService, IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork,
            IResponseBuilder responseBuilder, ILogger<AuthenticationController> logger, IValidator customerValidator)
        {
            _httpContextProxy = httpContextProxy;
            _unitOfWork = unitOfWork;
            _responseBuilder = responseBuilder;
            _authService = authService;
            _logger = logger;
            _customerValidator = customerValidator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<JObject> Login()
        {
            try
            {
                var inputModel = _httpContextProxy.GetRequestBody<LoginModel>();
                var listOfErrors = _customerValidator.Validate(inputModel);
                if (listOfErrors.Count() > 0)
                {
                    return _responseBuilder.BadRequest(listOfErrors.ToJArray());

                };

                var (status, data) = await _authService.Login(inputModel);
                if (status == 0)
                    return _responseBuilder.BadRequest(data.ToJObject());
                return _responseBuilder.Success(data.ToJObject());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JObject> Register()
        {
            IDbContextTransaction trans = null;
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {

                    var inputModel = _httpContextProxy.GetRequestBody<UserModel>();
                    var listOfErrors = _customerValidator.Validate(inputModel);
                    if (listOfErrors.Count() > 0)
                    {
                        return _responseBuilder.BadRequest(listOfErrors.ToJArray());

                    };

                    var (status, data) = await _authService.RegisterationAsync(inputModel);

                    if (status == 0)
                    {
                        return _responseBuilder.BadRequest(data.ToJObject());
                    }
                    await trans.CommitAsync();

                    return _responseBuilder.Success("User Registered.");

                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    _logger.LogError(ex.Message);
                    return _responseBuilder.ServerError(ex.Message);
                }
            }
        }

        [HttpPost]
        [Route("CreateRole")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> CreateRole()
        {

            IDbContextTransaction trans = null;
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {

                    RoleModel roleData = _httpContextProxy.GetRequestBody<RoleModel>();
                    var isExists = await _authService.IsRoleExists(roleData.Name);
                    if (!isExists)
                    {
                        var (status, data) = await _authService.CreateRole(roleData);

                        if (status == 0)
                        {
                            return _responseBuilder.BadRequest(data.ToJObject(), null);
                        }
                        await trans.CommitAsync();
                        return _responseBuilder.Success(data.ToJObject(), null);
                    }
                    else
                        return _responseBuilder.BadRequest("Role exists.Please use different name.", null);


                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    _logger.LogError(ex.Message);
                    return _responseBuilder.ServerError(ex.Message);
                }
            }

        }

        [HttpGet]
        [Route("GetAllRoles")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> GetAllRoles()
        {

            //IDbContextTransaction trans = null;
            try
            {

                var roles = await _authService.GetAllRoles();
                if (roles == null)
                {
                    return _responseBuilder.BadRequest("Roles does not exists.");
                }
                return _responseBuilder.Success(roles.ToJArray());


            }
            catch (Exception ex)
            {
                //trans.Rollback();
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }

        }

        [HttpPost]
        [Route("UpdateRoleAsync")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> UpdateRoleAsync()
        {

            //IDbContextTransaction trans = null;
            try
            {
                var roleObj = _httpContextProxy.GetRequestBody<RoleModel>();

                ApplicationRole role = new ApplicationRole();
                role.IsActive = roleObj.IsActive;
                role.Name = roleObj.Name;
                role.Id = roleObj.Id;
                role.IsAgent = roleObj.IsAgent;
                role.IsClient = roleObj.IsClient;
                role.NormalizedName = roleObj.Name;

                var (status, data) = await _authService.UpdateRole(role);
                if (status == 0)
                {
                    return _responseBuilder.BadRequest("Roles does not exists.", null);
                }
                return _responseBuilder.Success(data.Message);


            }
            catch (Exception ex)
            {
                //trans.Rollback();
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteRole")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> DeleteRole()
        {

            IDbContextTransaction trans = null;
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {

                    var roleId = int.Parse(_httpContextProxy.GetQueryString("_id"));
                    var res = await _authService.DeleteRole(roleId);
                    await trans.CommitAsync();
                    //var attachment = _unitOfWork.TicketAttachmentRepository.GetAsync(x => x.Id == attachmentId).Result.FirstOrDefault();
                    if (res)
                    {
                        return _responseBuilder.Success("Tickets updated.", null);
                    }
                    else
                    {
                        return _responseBuilder.BadRequest($"Could not delete role. ", null);
                    }


                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    _logger.LogError(ex.Message);
                    return _responseBuilder.BadRequest(ex.Message, null);
                }
            }

        }

        [HttpGet]
        [Route("GetAllRolesById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> GetAllRolesById()
        {

            //IDbContextTransaction trans = null;
            try
            {
                var id = int.Parse(_httpContextProxy.GetQueryString("_id"));
                var (status, data) = await _authService.GetRolesById(id);
                if (status == 0)
                {
                    return _responseBuilder.BadRequest(data.Message);
                }
                return _responseBuilder.Success(data.Result);


            }
            catch (Exception ex)
            {
                //trans.Rollback();
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }

        }

        [HttpPost]
        [Route("GetRequestors")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<JObject> GetRequestors()
        {

            try
            {
                var searchModel = _httpContextProxy.GetRequestBody<SearchModel>();

                //var dpt = _httpContextProxy.GetQueryString("_departmentId") != null ? _httpContextProxy.GetQueryString("_departmentId") : "0";
                ///var searchStr = _httpContextProxy.GetQueryString("_searchStr") != null ? _httpContextProxy.GetQueryString("_searchStr") : "";

                // var departmentId = int.Parse(dpt);
                //List<UserModel> result = null;
                var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
                var userRoles = db.UserRoles;

                var data = (from x in db.Users
                            .Where(x => searchModel.UserType == UserTypeEnum.CLIENT ? x.UserType == Infrastructure.Enums.UserTypeEnum.CLIENT : x.UserType == Infrastructure.Enums.UserTypeEnum.AGENT)
                            .Where(v => searchModel.DepartmentId > 0 ? v.DepartmentId == searchModel.DepartmentId : true)
                            .Where(c => searchModel.ShowAll == true ? true : c.Active == true)


                            join y in userRoles on x.Id equals y.UserId
                            join z in db.Roles on y.RoleId equals z.Id

                            select new UserModel
                            {
                                Id = x.Id,
                                DisplayName = x.FirstName + " " + x.LastName,
                                Email = x.Email,
                                PhoneNumber = x.PhoneNumber,
                                RoleName = z.RoleName,

                                UserName = x.UserName,
                                Address = x.Address,
                                City = x.City,
                                JobTitle = x.JobTitle,
                                State = x.State,
                                Active = x.Active,
                                ImageBytes = x.ImageBytes

                            }).AsEnumerable();

                if (searchModel != null)
                {
                    switch (searchModel.SearchOption)
                    {
                        case "1":
                            data = data.Where(x => x.DisplayName.StartsWith(searchModel.SearchString));
                            break;
                        case "2":
                            data = data.Where(x => x.UserName.StartsWith(searchModel.SearchString));
                            break;
                        case "3":
                            data = data.Where(x => x.Email.StartsWith(searchModel.SearchString));
                            break;
                        case "4":
                            data = data.Where(x => x.RoleName.StartsWith(searchModel.SearchString));
                            break;
                        case "5":
                            data = data.Where(x => x.JobTitle.StartsWith(searchModel.SearchString));
                            break;
                        case "6":
                            data = data.Where(x => x.PhoneNumber.StartsWith(searchModel.SearchString));
                            break;
                    }
                }


                return _responseBuilder.Success(data.ToJArray());


            }
            catch (Exception ex)
            {
                //trans.Rollback();
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetRequestorsByIdAsync")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> GetRequestorsByIdAsync()
        {

            try
            {
                var userType = _httpContextProxy.GetQueryString("_userType");
                var id = int.Parse(_httpContextProxy.GetQueryString("_Id"));
                //var dpt = _httpContextProxy.GetQueryString("_departmentId") != null ? _httpContextProxy.GetQueryString("_departmentId") : "0";

                // var departmentId = int.Parse(dpt);
                List<UserModel> result = null;
                var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
                var userRoles = db.UserRoles;

                var data = (from x in db.Users
                            .Where(x => userType == "CLIENT" ? x.UserType == Infrastructure.Enums.UserTypeEnum.CLIENT : x.UserType == Infrastructure.Enums.UserTypeEnum.AGENT)
                            .Where(v => v.Id == id)
                            join y in userRoles on x.Id equals y.UserId
                            join z in db.Roles on y.RoleId equals z.Id

                            select new UserModel
                            {
                                Id = x.Id,
                                DisplayName = x.FirstName + " " + x.LastName,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                Email = x.Email,
                                PhoneNumber = x.PhoneNumber,
                                RoleName = z.RoleName,

                                UserName = x.UserName,
                                Address = x.Address,
                                City = x.City,
                                JobTitle = x.JobTitle,
                                State = x.State,
                                Active = x.Active,
                                ImageBytes = x.ImageBytes

                            }).ToList();


                return _responseBuilder.Success(data.ToJArray());


            }
            catch (Exception ex)
            {
                //trans.Rollback();
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> GetUser()
        {
            try
            {
                var id = _httpContextProxy.GetQueryString("_Id");
                var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
                var userDetails = db.Users.Where(x => x.UserName == id).FirstOrDefault();
                return _responseBuilder.Success(userDetails.ImageBytes);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetTechnicians")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> GetTechniciansById()
        {
            try
            {
                List<UserModel> result = null;

                var id = int.Parse(_httpContextProxy.GetQueryString("_Id"));
                var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
                var userRoles = db.UserRoles;

                var data = (from x in db.Users.Where(x => x.UserType == Infrastructure.Enums.UserTypeEnum.AGENT && x.Id == id)
                            join y in userRoles on x.Id equals y.UserId
                            join z in db.Roles on y.RoleId equals z.Id

                            select new UserModel
                            {
                                Id = x.Id,
                                DisplayName = x.FirstName,
                                Email = x.Email,
                                PhoneNumber = x.PhoneNumber,
                                RoleName = z.RoleName,
                                UserName = x.UserName,
                                Address = x.Address,
                                City = x.City,
                                JobTitle = x.JobTitle,
                                State = x.State,
                                Active = x.Active,
                            }).ToList();


                return _responseBuilder.Success(data.ToJArray());


            }
            catch (Exception ex)
            {
                //trans.Rollback();
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> UpdateUser()
        {
            IDbContextTransaction trans = null;
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {
                    var inputModel = _httpContextProxy.GetRequestBody<UserModel>();

                    if (inputModel.OperationContext == OperationContextEnum.DELETEUSER)
                    {
                        var tckts = await _unitOfWork.TicketRepository.GetAsync(x => x.Tkt_RequestUserId == inputModel.Id || x.Tkt_AssignedUserId == inputModel.Id);
                        if (tckts != null)
                        {
                            return _responseBuilder.BadRequest("User has tickets associated.Cannot delete user.", null);
                        }
                    }
                    var (status, data) = await _authService.UpdateUser(inputModel);

                    if (status == 0)
                    {
                        return _responseBuilder.BadRequest(data.ToJObject());
                    }
                    await trans.CommitAsync();

                    return _responseBuilder.Success(data.Message, null);
                }
                catch (Exception ex)
                {

                    await trans.RollbackAsync();
                    _logger.LogError(ex.Message);
                    return _responseBuilder.ServerError(ex.Message);
                }
            }
        }

        [HttpPost]
        [Route("UpdateClaims")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> UpdateClaims()
        {
            IDbContextTransaction trans = null;
            var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
            Dictionary<string, string> claims = new Dictionary<string, string>();
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {
                    var inputModel = _httpContextProxy.GetRequestBody<List<UserRolePermissionModel>>();
                    if (inputModel == null)
                    {
                        return _responseBuilder.BadRequest("No input .", null);
                    }

                    var user = db.Users.Where(x => x.Id == inputModel.FirstOrDefault().UserId).FirstOrDefault();

                    foreach (var item in inputModel)
                    {
                        var role = db.Roles.Where(x => x.Id == item.RoleId && x.IsActive == true).FirstOrDefault();
                        if (role != null)
                        {
                            claims.Add(nameof(RoleClaimEnum.NEWLIST), item.RoleClaim.IsNewListAccess.ToString() == "" ? "false" : item.RoleClaim.IsNewListAccess.ToString());
                            claims.Add(nameof(RoleClaimEnum.OPENLIST), item.RoleClaim.IsOpenListAccess.ToString() == "" ? "false" : item.RoleClaim.IsOpenListAccess.ToString());
                            claims.Add(nameof(RoleClaimEnum.COMPLETEDLIST), item.RoleClaim.IsCompletedListAccess.ToString() == "" ? "false" : item.RoleClaim.IsCompletedListAccess.ToString());
                            claims.Add(nameof(RoleClaimEnum.DUETODAYLIST), item.RoleClaim.IsDueTodayListAccess.ToString() == "" ? "false" : item.RoleClaim.IsDueTodayListAccess.ToString());
                            claims.Add(nameof(RoleClaimEnum.OVERDUELIST), item.RoleClaim.IsOverDueListAccess.ToString() == "" ? "false" : item.RoleClaim.IsOverDueListAccess.ToString());

                            claims.Add(nameof(RoleClaimEnum.MASTERDATA), item.RoleClaim.IsMasterDataListAccess.ToString() == "" ? "false" : item.RoleClaim.IsMasterDataListAccess.ToString());
                            claims.Add(nameof(RoleClaimEnum.APPSETTING), item.RoleClaim.IsAppSettingAccess.ToString() == "" ? "false" : item.RoleClaim.IsAppSettingAccess.ToString());
                            claims.Add(nameof(RoleClaimEnum.RESOLVEDLIST), item.RoleClaim.IsResolvedListAccess.ToString() == "" ? "false" : item.RoleClaim.IsResolvedListAccess.ToString());



                            var (status, data) = await _authService.UpdateRoleClaim(role, user, claims);
                            if (status == 0)
                            {
                                return _responseBuilder.ServerError(data.ToJObject());
                            }
                            claims = new Dictionary<string, string>();
                            claims.Add(nameof(UserClaimEnum.FULLACCESS), item.UserClaim.IsFullAccess.ToString() == "" ? "false" : item.UserClaim.IsFullAccess.ToString());
                            claims.Add(nameof(UserClaimEnum.VIEWACCESS), item.UserClaim.IsViewAccess.ToString() == "" ? "false" : item.UserClaim.IsViewAccess.ToString());
                            claims.Add(nameof(UserClaimEnum.EDITACCESS), item.UserClaim.IsEditAccess.ToString() == "" ? "false" : item.UserClaim.IsEditAccess.ToString());
                            claims.Add(nameof(UserClaimEnum.ADDACCESS), item.UserClaim.IsAddAccess.ToString() == "" ? "false" : item.UserClaim.IsAddAccess.ToString());
                            claims.Add(nameof(UserClaimEnum.DELETEACCESS), item.UserClaim.IsDeleteAccess.ToString() == "" ? "false" : item.UserClaim.IsDeleteAccess.ToString());

                            claims.Add(nameof(UserClaimEnum.PRINTACCESS), item.UserClaim.IsPrintAccess.ToString() == "" ? "false" : item.UserClaim.IsPrintAccess.ToString());
                            claims.Add(nameof(UserClaimEnum.EXPORTACCESS), item.UserClaim.IsIsExportAccess.ToString() == "" ? "false" : item.UserClaim.IsIsExportAccess.ToString());
                            claims.Add(nameof(UserClaimEnum.UPDATETICKETSTATUS), item.UserClaim.IsUpdateTicketStatusAccess.ToString() == "" ? "false" : item.UserClaim.IsUpdateTicketStatusAccess.ToString());

                            var (status1, data1) = await _authService.UpdateUserClaim(user, claims);
                            if (status1 == 0)
                            {
                                return _responseBuilder.ServerError(data1.ToJObject());
                            }


                        }
                    }
                    await trans.CommitAsync();

                    return _responseBuilder.Success("User role permission updated.", null);

                }
                catch (Exception ex)
                {

                    await trans.RollbackAsync();
                    _logger.LogError(ex.Message);
                    return _responseBuilder.ServerError(ex.Message);
                }
            }
        }

        [HttpPost]
        [Route("GetUserRoleClaims")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> GetUserRoleClaims()
        {
            var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
            try
            {
                var inputModel = _httpContextProxy.GetRequestBody<UserRoleModel>();
                if (inputModel == null)
                {
                    return _responseBuilder.BadRequest("Input data is missing", null);
                }
                ApplicationUser user = db.Users.Where(x => x.Id == inputModel.UserId).FirstOrDefault();

                var (data, result) = await _authService.GetUserRoleClaims(user, inputModel.UserType, inputModel.RoleName, inputModel.RoleId);
                //var (data1, result1) = await _authService.GetUserClaims(user, inputModel.UserType, inputModel.RoleName, inputModel.RoleId);
                // var da = JsonConvert.DeserializeObject<UserRolePermissionModel>(result.Result);


                return _responseBuilder.Success(result.Result, null);

            }
            catch (Exception ex)
            {


                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }

        [HttpPost]
        [Route("ResetPasswordFromAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<JObject> ResetPasswordFromAdmin()
        {
            IDbContextTransaction trans = null;
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {
                    var inputModel = _httpContextProxy.GetRequestBody<UserModel>();
                    var retVal = await _authService.ResetPasswordFromAdmin(inputModel);

                    if (retVal == false)
                    {
                        return _responseBuilder.BadRequest(false);
                    }
                    await trans.CommitAsync();

                    return _responseBuilder.Success(true, null);
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    _logger.LogError(ex.Message);
                    return _responseBuilder.ServerError(ex.Message);
                }

            }
        }

        [HttpPost]
        [Route("ForgotPassword")]

        public async Task<JObject> ForgotPassword()
        {
            try
            {
                var inputModel = _httpContextProxy.GetRequestBody<ForgotPasswordModel>();
                var listOfErrors = _customerValidator.Validate(inputModel);
                if (listOfErrors.Count() > 0)
                {
                    return _responseBuilder.BadRequest(listOfErrors.ToJArray());
                };

                var (status, retVal) = await _authService.ForgotPassword(inputModel);

                if (status == 0)
                {
                    return _responseBuilder.ServerError(retVal.Message);
                }


                return _responseBuilder.Success(retVal.ToJObject(), null);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<JObject> ResetPassword()
        {
            try
            {
                var inputModel = _httpContextProxy.GetRequestBody<ResetPasswordModel>();
                var listOfErrors = _customerValidator.Validate(inputModel);
                if (listOfErrors.Count() > 0)
                {
                    return _responseBuilder.BadRequest(listOfErrors.ToJArray());
                };

                var (status, retVal) = await _authService.ResetPassword(inputModel);
                if (status == 0)
                {
                    return _responseBuilder.ServerError(retVal.Message);
                }


                return _responseBuilder.Success(retVal.ToJObject(), null);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }

        }



    }

}
