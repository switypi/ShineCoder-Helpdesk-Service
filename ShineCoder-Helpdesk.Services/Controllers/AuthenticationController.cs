using System.Linq;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core;
using ShineCoder_Helpdesk.Core.Helpers;
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

				var (status, message) = await _authService.Login(inputModel);
				if (status == 0)
					return _responseBuilder.BadRequest(message.ToJObject());
				return _responseBuilder.Success(message.ToJObject());
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
			try
			{

				var inputModel = _httpContextProxy.GetRequestBody<RegistrationModel>();
				var listOfErrors = _customerValidator.Validate(inputModel);
				if (listOfErrors.Count() > 0)
				{
					return _responseBuilder.BadRequest(listOfErrors.ToJArray());

				};
				using (trans = _unitOfWork.GetDbTransaction)
				{
					var (status, message) = await _authService.Registeration(inputModel, UserRolesValues.User);

					if (status == 0)
					{
						return _responseBuilder.BadRequest(message.ToJObject());
					}
					trans.Commit();
				}
				return _responseBuilder.Success("User Registered.");

			}
			catch (Exception ex)
			{
				trans.Rollback();
				_logger.LogError(ex.Message);
				return _responseBuilder.ServerError(ex.Message);
			}
		}

		[HttpPost]
		[Route("CreateRole")]
		public async Task<JObject> CreateRole()
		{

			IDbContextTransaction trans = null;
			try
			{
				using (trans = _unitOfWork.GetDbTransaction)
				{
					var roleName = _httpContextProxy.GetQueryString("roleName");
					var (status, message) = await _authService.CreateRole(roleName);
					if (status == 0)
					{
						return _responseBuilder.BadRequest(message.ToJObject());
					}
					return _responseBuilder.Success(message.ToJObject());

				}
			}
			catch (Exception ex)
			{
				trans.Rollback();
				_logger.LogError(ex.Message);
				return _responseBuilder.ServerError(ex.Message);
			}
			
		}

		[HttpGet]
		[Route("GetAllRoles")]
		public async Task<JObject> GetAllRoles()
		{

			IDbContextTransaction trans = null;
			try
			{
				using (trans = _unitOfWork.GetDbTransaction)
				{
					var (status, message) = await _authService.GetAllRoles();
					if (status == 0)
					{
						return _responseBuilder.BadRequest(message.ToJObject());
					}
					return _responseBuilder.Success(message.ToJObject());

				}
			}
			catch (Exception ex)
			{
				trans.Rollback();
				_logger.LogError(ex.Message);
				return _responseBuilder.ServerError(ex.Message);
			}

		}

	}
}
