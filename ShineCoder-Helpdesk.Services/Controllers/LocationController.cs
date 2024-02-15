using AutoMapper;
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
	[Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.LOCATION_SERVICE_API_PREFIX)]
	[ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
	public class LocationController : ControllerBase
	{
		private readonly IHttpContextProxy _httpContextProxy;
		private readonly IUnitOfWork _unitOfWork;
		protected readonly IResponseBuilder _responseBuilder;
		private readonly ILogger _logger;
		private readonly IValidator _customerValidator;
		private readonly IMapper _mapper;
		public LocationController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
			ILogger<LocationController> logger, IValidator customerValidator, IMapper mapper)
		{
			_httpContextProxy = httpContextProxy;
			_unitOfWork = unitOfWork;
			_responseBuilder = responseBuilder;
			_logger = logger;
			_customerValidator = customerValidator;
			_mapper = mapper;
		}
		[HttpGet]
		[Route("GetLocationAsyn")]
		public async Task<JObject> GetLocationAsyn()
		{
			try
			{
				var data = await _unitOfWork.LocationRepository.GetAsync();
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}
		[HttpGet]
		[Route("GetLocationByIdAsyn")]
		public async Task<JObject> GetLocationByIdAsyn()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("_Id"));

				var data = _unitOfWork.LocationRepository.GetAsync(x => x.Id == id);

				return _responseBuilder.Success(data.ToJObject());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpPost]
		[Route("CreateLocationyAsyn")]
		public async Task<JObject> CreateLocationyAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<LocationModel>();
					var outputModel = _mapper.Map<Location>(inputData);
					_unitOfWork.LocationRepository.InsertAsyn(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Location created.");
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
		[Route("DeleteLocationAsyn")]
		public async Task<JObject> DeleteLocationAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<LocationModel>();
					var outputModel = _mapper.Map<Location>(inputData);

					_unitOfWork.LocationRepository.DeleteAsync(outputModel.Id);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Location deleted.");
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
		[Route("UpdateLocationAsyn")]
		public async Task<JObject> UpdateLocationAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<LocationModel>();
					var outputModel = _mapper.Map<Location>(inputData);

					_unitOfWork.LocationRepository.UpdateAsync(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Location updated.");
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
