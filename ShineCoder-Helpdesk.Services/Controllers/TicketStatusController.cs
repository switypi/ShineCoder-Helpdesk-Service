using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShineCoder_Helpdesk.Core.Helpers;
using ShineCoder_Helpdesk.Core;
using ShineCoder_Helpdesk.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Services.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketStatusController : ControllerBase
	{
		private readonly IHttpContextProxy _httpContextProxy;
		private readonly IUnitOfWork _unitOfWork;
		protected readonly IResponseBuilder _responseBuilder;
		private readonly ILogger _logger;
		private readonly IValidator _customerValidator;
		private readonly IMapper _mapper;
		public TicketStatusController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
			ILogger<TicketStatusController> logger, IValidator customerValidator, IMapper mapper)
		{
			_httpContextProxy = httpContextProxy;
			_unitOfWork = unitOfWork;
			_responseBuilder = responseBuilder;
			_logger = logger;
			_customerValidator = customerValidator;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("GetTicketrStatusAsyn")]
		public async Task<JObject> GetTicketrStatusAsyn()
		{
			try
			{
				var data = await _unitOfWork.TicketStatusRepository.GetAsync();
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpGet]
		[Route("GetTicketrStatusByIdAsyn")]
		public async Task<JObject> GetTicketrStatusByIdAsyn()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("_Id"));

				var data = _unitOfWork.TicketStatusRepository.GetAsync(x => x.Id == id);

				return _responseBuilder.Success(data.ToJObject());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpPost]
		[Route("CreateTicketStatusAsyn")]
		public async Task<JObject> CreateTicketStatusAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<StatusModel>();
					var outputModel = _mapper.Map<Ticket_Status>(inputData);
					_unitOfWork.TicketStatusRepository.InsertAsyn(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Ticket Status created.");
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
		[Route("DeleteTicketStatusAsyn")]
		public async Task<JObject> DeleteTicketStatusAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<StatusModel>();
					var outputModel = _mapper.Map<Ticket_Status>(inputData);

					_unitOfWork.TicketStatusRepository.DeleteAsync(outputModel.Id);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Ticket Status deleted.");
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
		[Route("UpdateTicketStatusAsyn")]
		public async Task<JObject> UpdateTicketStatusAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<StatusModel>();
					var outputModel = _mapper.Map<Ticket_Status>(inputData);

					_unitOfWork.TicketStatusRepository.UpdateAsync(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Ticket Status updated.");
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
