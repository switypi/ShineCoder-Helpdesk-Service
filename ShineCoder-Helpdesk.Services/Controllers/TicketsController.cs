using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Repository;
using ShineCoder_Helpdesk.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ShineCoder_Helpdesk.Infrastructure.Models;
using ShineCoder_Helpdesk.Infrastructure;
using AutoMapper;
using ShineCoder_Helpdesk.Core.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Swashbuckle.AspNetCore.Annotations;
using ShineCoder_Helpdesk.Core.Enums;
using System.Diagnostics;
using System.Security.Claims;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShineCoder_Helpdesk.Services.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.TICKETS_SERVICE_API_PREFIX)]
	[ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class TicketsController : ControllerBase
	{

		private readonly IHttpContextProxy _httpContextProxy;
		private readonly IUnitOfWork _unitOfWork;
		protected readonly IResponseBuilder _responseBuilder;
		private readonly ILogger _logger;
		private readonly IValidator _customerValidator;
		private readonly IMapper _mapper;

		public TicketsController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
			ILogger<AuthenticationController> logger, IValidator customerValidator, IMapper mapper)
		{
			_httpContextProxy = httpContextProxy;
			_unitOfWork = unitOfWork;
			_responseBuilder = responseBuilder;
			_logger = logger;
			_customerValidator = customerValidator;
			_mapper = mapper;
		}
		[HttpGet]
		[Route("GetAllTickets")]

		public async Task<JObject> GetAllTicketsAsyn()
		{
			try
			{
				var ticketData = await _unitOfWork.TicketRepository.GetAsync(x => x.Active == true);
				return _responseBuilder.Success(ticketData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}

		[HttpGet]
		[Route("GetOpenTickets")]
		public async Task<JObject> GetOpenTicketsAsync()
		{
			try
			{
				var ticketData = await _unitOfWork.TicketRepository.GetAsync(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Open);
				return _responseBuilder.Success(ticketData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}

		[HttpGet]
		[Route("GetAssignedTickets")]
		public async Task<JObject> GetAssignedTicketsAsync()
		{
			try
			{
				var ticketData =await _unitOfWork.TicketRepository.GetAsync(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Assigned);
				return _responseBuilder.Success(ticketData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}

		[HttpGet]
		[Route("GetNewTickets")]
		public async Task<JObject> GetNewTicketsAsync()
		{
			try
			{
				var ticketData =await _unitOfWork.TicketRepository.GetAsync(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.New);
				return _responseBuilder.Success(ticketData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}

		[HttpGet]
		[Route("GetResolvedTickets")]
		public async Task<JObject> GetResolvedTicketsAsync()
		{
			try
			{
				var ticketData = await _unitOfWork.TicketRepository.GetAsync(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Resolved);
				return _responseBuilder.Success(ticketData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}

		// GET api/<TicketsController>/5
		[HttpPost]
		[Route("CreateTickets")]

		public async Task<JObject> CreateTicketsAsync()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{

					var inputModel = _httpContextProxy.GetRequestBody<TicketsModel>();
					var listOfErrors = _customerValidator.Validate(inputModel);
					if (listOfErrors.Count() > 0)
					{
						return _responseBuilder.BadRequest(listOfErrors.ToJArray());

					};
					var outputModel = _mapper.Map<Tickets>(inputModel);
					_unitOfWork.TicketRepository.InsertAsyn(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Tickets created.");


				}
				catch (Exception ex)
				{
					await trans.RollbackAsync();
					_logger.LogError(ex.Message);
					return _responseBuilder.BadRequest(ex.Message);
				}
			}
		}

		// POST api/<TicketsController>
		[HttpPost]
		[Route("UpdateTickets")]
		public async Task<JObject> UpdateTicketsAsync()
		{
			try
			{
				var inputModel = _httpContextProxy.GetRequestBody<Tickets>();


				var listOfErrors = _customerValidator.Validate(inputModel);
				if (listOfErrors.Count() > 0)
				{
					return _responseBuilder.BadRequest(listOfErrors.ToJArray());

				};
				var tickets = _unitOfWork.TicketRepository.GetAsync(x => x.Id == inputModel.Id).Result.FirstOrDefault();

				if (tickets != null)
				{
					var outputModel = _mapper.Map<Tickets>(inputModel);
					_unitOfWork.TicketRepository.UpdateAsync(outputModel);
					await _unitOfWork.SaveAsync();
				}

				return _responseBuilder.Success("Tickets updated.");
			}
			catch (Exception ex)
			{

				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}
		}

		// PUT api/<TicketsController>/5
		[HttpDelete]
		[Route("DeleteTicket")]
		public async Task<JObject> DeleteTicket()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{

					var ticketId = int.Parse(_httpContextProxy.GetQueryString("ticketId"));
					var tickets = _unitOfWork.TicketRepository.GetAsync(x => x.Id == ticketId).Result.FirstOrDefault();
					if (tickets != null)
					{
						_unitOfWork.TicketRepository.Delete(tickets);
						await _unitOfWork.SaveAsync();
						await trans.CommitAsync();
						return _responseBuilder.Success("Tickets updated.");
					}
					else
					{
						return _responseBuilder.Success($"Could not find tickets with ticketId = {ticketId}");
					}


				}
				catch (Exception ex)
				{
					await trans.RollbackAsync();
					_logger.LogError(ex.Message);
					return _responseBuilder.BadRequest(ex.Message);
				}
			}
		}

		[HttpPost]
		[Route("AssignTickets")]
		public async Task<JObject> AssignTicketsAsync()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{

					var ticketObj = _httpContextProxy.GetRequestBody<TicketAssignedModel>();

					var tickets = _unitOfWork.TicketRepository.GetAsync(x => x.Id == ticketObj.TicketId).Result.FirstOrDefault();
					if (tickets != null)
					{
						tickets.Tkt_AssignedUserId = ticketObj.AssignedUserId;
						_unitOfWork.TicketRepository.UpdateAsync(tickets);
						await _unitOfWork.SaveAsync();
						await trans.CommitAsync();
						return _responseBuilder.Success("Tickets updated.");
					}
					else
					{
						return _responseBuilder.Success($"Could not find tickets with ticketId = {ticketObj.TicketId}");
					}
					

				}
				catch (Exception ex)
				{
					await trans.RollbackAsync();
					_logger.LogError(ex.Message);
					return _responseBuilder.BadRequest(ex.Message);
				}
			}
		}


	}
}
