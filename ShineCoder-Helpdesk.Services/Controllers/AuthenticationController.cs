using System;
using System.Diagnostics;
using System.Linq;
using Azure;
using Microsoft.AspNetCore.Http;
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

					var (status, data) = await _authService.RegisterationAsync(inputModel, inputModel.RoleName == "AGENT" ? UserRolesValues.Agent : UserRolesValues.Client);

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

					var roleName = _httpContextProxy.GetQueryString("roleName");
					var (status, data) = await _authService.CreateRole(roleName);

					if (status == 0)
					{
						return _responseBuilder.BadRequest(data.ToJObject());
					}
					await trans.CommitAsync();
					return _responseBuilder.Success(data.ToJObject());


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

				var (status, data) = await _authService.GetAllRoles();
				if (status == 0)
				{
					return _responseBuilder.BadRequest(data.ToJObject());
				}
				return _responseBuilder.Success(data.ToJObject());


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
					//var listOfErrors = _customerValidator.Validate(inputModel);
					//if (listOfErrors.Count() > 0)
					//{
					//	return _responseBuilder.BadRequest(listOfErrors.ToJArray());

					//};

					if(inputModel.OperationContext==OperationContextEnum.DELETEUSER)
					{
						var tckts = await _unitOfWork.TicketRepository.GetAsync(x => x.Tkt_RequestUserId == inputModel.Id || x.Tkt_AssignedUserId==inputModel.Id);
						if (tckts != null)
						{
							return _responseBuilder.BadRequest("User has tickets associated.Cannot delete user.",null);
						}
					}
					var (status, data) = await _authService.UpdateUser(inputModel);

					if (status == 0)
					{
						return _responseBuilder.BadRequest(data.ToJObject());
					}
					await trans.CommitAsync();

					return _responseBuilder.Success("User updated.");
				}
				catch (Exception ex)
				{

					await trans.RollbackAsync();
					_logger.LogError(ex.Message);
					return _responseBuilder.ServerError(ex.Message);
				}
			}
		}




	}
}
