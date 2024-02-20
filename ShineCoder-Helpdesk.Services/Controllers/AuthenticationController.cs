using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Azure;
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
        public async Task<JObject> DeleteRole()
        {

            IDbContextTransaction trans = null;
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {

                    var roleId = int.Parse(_httpContextProxy.GetQueryString("_id"));
                    var res = await _authService.DeleteRole(roleId);
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

        [HttpGet]
        [Route("GetRequestors")]
        public async Task<JObject> GetRequestors()
        {

            try
            {
                var userType = _httpContextProxy.GetQueryString("_userType");
                var dpt = _httpContextProxy.GetQueryString("_departmentId") != null ? _httpContextProxy.GetQueryString("_departmentId") : "0";

                var departmentId = int.Parse(dpt);
                List<UserModel> result = null;
                var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
                var userRoles = db.UserRoles;

                var data = (from x in db.Users
                            .Where(x => userType == "CLIENT" ? x.UserType == Infrastructure.Enums.UserTypeEnum.CLIENT : x.UserType == Infrastructure.Enums.UserTypeEnum.AGENT)
                            .Where(v => departmentId > 0 ? v.DepartmentId == departmentId : true)
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
        [Route("GetRequestorsByIdAsync")]
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
        public async Task<JObject> UpdateClaims()
        {
            IDbContextTransaction trans = null;
            var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
            Dictionary<string, string> claims = new Dictionary<string, string>();
            using (trans = _unitOfWork.GetDbTransaction)
            {
                try
                {
                    var inputModel = _httpContextProxy.GetRequestBody<UserRolePermissionModel>();
                    var user = db.Users.Where(x => x.Id == inputModel.UserId).FirstOrDefault();
                    
                    foreach(var item in inputModel.RoleIds)
                    {
                        var role= db.Roles.Where(x=>x.Id==item && x.IsActive==true);
                        if (role != null)
                        {
                            claims.Add(nameof( ClaimEnum.FULLACCESS),inputModel.IsFullAccess.ToString());
                            claims.Add(nameof(ClaimEnum.VIEW), inputModel.IsViewAccess.ToString());
                            claims.Add(nameof(ClaimEnum.EDIT), inputModel.IsEditAccess.ToString());
                            claims.Add(nameof(ClaimEnum.ADD), inputModel.IsAddAccess.ToString());

                            var(status, data)= await _authService.UpdateUserClaim(role,user, claims);
                            if (status == 0)
                            {
                                return _responseBuilder.ServerError(data.ToJObject());
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
        public async Task<object> GetUserRoleClaims()
        {
            try
            {
                var inputModel = _httpContextProxy.GetRequestBody<UserRoleModel>();

                

                return _responseBuilder.Success("User role permission updated.", null);

            }
            catch (Exception ex)
            {

                
                _logger.LogError(ex.Message);
                return _responseBuilder.ServerError(ex.Message);
            }
        }



    }
}
