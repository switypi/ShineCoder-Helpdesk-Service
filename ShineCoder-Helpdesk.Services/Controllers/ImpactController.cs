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
	[Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.IMPACT_SERVICE_API_PREFIX)]
	[ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
	public class ImpactController : ControllerBase
	{
		private readonly IHttpContextProxy _httpContextProxy;
		private readonly IUnitOfWork _unitOfWork;
		protected readonly IResponseBuilder _responseBuilder;
		private readonly ILogger _logger;
		private readonly IValidator _customerValidator;
		private readonly IMapper _mapper;
		public ImpactController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
			ILogger<ImpactController> logger, IValidator customerValidator, IMapper mapper)
		{
			_httpContextProxy = httpContextProxy;
			_unitOfWork = unitOfWork;
			_responseBuilder = responseBuilder;
			_logger = logger;
			_customerValidator = customerValidator;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("GetImpactsAsyn")]
		public async Task<JObject> GetImpactsAsyn()
		{
			try
			{
				var data = await _unitOfWork.ImpactRepository.GetAsync();
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpGet]
		[Route("GetImpactByIdAsync")]
		public async Task<JObject> GetImpactByIdAsync()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("_Id"));

				var data = _unitOfWork.ImpactRepository.GetAsync(x => x.Id == id);

				return _responseBuilder.Success(data.ToJObject());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpPost]
		[Route("CreateImpactAsyn")]
		public async Task<JObject> CreateImpactAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<ImpactModel>();
					var outputModel = _mapper.Map<Ticket_Impact>(inputData);
					_unitOfWork.ImpactRepository.InsertAsyn(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Impact created.");
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
		[Route("DeleteImpactAsyn")]
		public async Task<JObject> DeleteImpactAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<ImpactModel>();
					var outputModel = _mapper.Map<Ticket_Impact>(inputData);

					_unitOfWork.ImpactRepository.DeleteAsync(outputModel.Id);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Ticket Impact deleted.");
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
		[Route("UpdateImpactAsyn")]
		public async Task<JObject> UpdateImpactAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<ImpactModel>();
					var outputModel = _mapper.Map<Ticket_Impact>(inputData);

					_unitOfWork.ImpactRepository.UpdateAsync(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Ticket Impact updated.");
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
