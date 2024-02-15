using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core;
using ShineCoder_Helpdesk.Core.Helpers;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure.Models;
using ShineCoder_Helpdesk.Repository;


namespace ShineCoder_Helpdesk.Services.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.ADMIN_SETTING_SERVICE_API_PREFIX)]
    [ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdminSettingsController : ControllerBase
    {
        private readonly IHttpContextProxy _httpContextProxy;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IResponseBuilder _responseBuilder;
        private readonly ILogger _logger;
        private readonly IValidator _customerValidator;
        private readonly IMapper _mapper;
        public AdminSettingsController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
            ILogger<AdminSettingsController> logger, IValidator customerValidator, IMapper mapper)
        {
            _httpContextProxy = httpContextProxy;
            _unitOfWork = unitOfWork;
            _responseBuilder = responseBuilder;
            _logger = logger;
            _customerValidator = customerValidator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetRequestTypes")]
        public async Task<JObject> GetRequestTypes()
        {
            try
            {
                var categoryData = await _unitOfWork.RequestTypeRepository.GetAsync(x => x.Active == true);
                return _responseBuilder.Success(categoryData.ToJArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.BadRequest(ex.Message,null);
            }

        }

		[HttpGet]
		[Route("GetPrioritiesAsync")]
		public async Task<JObject> GetPrioritiesAsync()
		{
			try
			{
				var data = await _unitOfWork.TicketPrioritiesRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpGet]
		[Route("GetImpactsAsync")]
		public async Task<JObject> GetImpactsAsync()
		{
			try
			{
				var data = await _unitOfWork.ImpactRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}
		[HttpGet]
		[Route("GetStatusAsync")]
		public async Task<JObject> GetStatusAsync()
		{
			try
			{
				var data = await _unitOfWork.TicketStatusRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpGet]
		[Route("GetRequestModesAsync")]
		public async Task<JObject> GetRequestModesAsync()
		{
			try
			{
				var data = await _unitOfWork.TicketModeRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}
		[HttpGet]
		[Route("GetUrgencyAsync")]
		public async Task<JObject> GetUrgencyAsync()
		{
			try
			{
				var data = await _unitOfWork.UrgencyRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpGet]
		[Route("GetDepartsAsync")]
		public async Task<JObject> GetDepartsAsync()
		{
			try
			{
				var data = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpGet]
		[Route("GetProductsAsync")]
		public async Task<JObject> GetProductsAsync()
		{
			try
			{
				var data = await _unitOfWork.ProductRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

        [HttpGet]
        [Route("GetuserLocationAsync")]
        public async Task<JObject> GetuserLocationAsync()
        {
            try
            {
                var data = await _unitOfWork.LocationRepository.GetAsync(x => x.Active == true);
                return _responseBuilder.Success(data.ToJArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.BadRequest(ex.Message,null);
            }

        }
        [HttpGet]
        [Route("GetTicketLevelAsync")]
        public async Task<JObject> GetTicketLevelAsync()
        {
            try
            {
                var data = await _unitOfWork.TicketLevelRepository.GetAsync(x => x.Active == true);
                return _responseBuilder.Success(data.ToJArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.BadRequest(ex.Message,null);
            }

        }

        [HttpGet]
        [Route("GetCategoriesAsync")]
        public async Task<JObject> GetCategoriesAsync()
        {
            try
            {
                var categoryData = await _unitOfWork.CategorysRepository.GetAsync(x => x.Active == true);
                return _responseBuilder.Success(categoryData.ToJArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.BadRequest(ex.Message,null);
            }

        }

        [HttpGet]
        [Route("GetDepartmentsAsync")]
        public async Task<JObject> GetDepartmentsAsync()
        {
            try
            {
                var categoryData = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Active == true);
                return _responseBuilder.Success(categoryData.ToJArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.BadRequest(ex.Message,null);
            }

        }
    }
}
