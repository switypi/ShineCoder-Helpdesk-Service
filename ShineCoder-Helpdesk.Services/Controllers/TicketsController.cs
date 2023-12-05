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

		public TicketsController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
			ILogger<AuthenticationController> logger, IValidator customerValidator)
		{
			_httpContextProxy = httpContextProxy;
			_unitOfWork = unitOfWork;
			_responseBuilder = responseBuilder;
			_logger = logger;
			_customerValidator = customerValidator;
		}
		[HttpGet]
		[Route("GetTickets")]

		public JObject GetTickets()
		{
			var studentData = _unitOfWork.TicketRepository.Get();
			return _responseBuilder.Success(studentData.ToJArray());
		}

		// GET api/<TicketsController>/5
		[HttpPost]
		[Route("CreateTickets")]
		public JObject CreateTickets()
		{
			try
			{
				var inputModel = _httpContextProxy.GetRequestBody<Tickets>();
				var listOfErrors = _customerValidator.Validate(inputModel);
				if (listOfErrors.Count() > 0)
				{
					return _responseBuilder.BadRequest(listOfErrors.ToJArray());

				};
				_unitOfWork.TicketRepository.Insert(inputModel);

				return _responseBuilder.Success("Tickets created.");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}
		}

		// POST api/<TicketsController>
		[HttpPost]
		[Route("UpdateTickets")]
		public JObject UpdateTickets()
		{
			try
			{
				var inputModel = _httpContextProxy.GetRequestBody<Tickets>();
				var listOfErrors = _customerValidator.Validate(inputModel);
				if (listOfErrors.Count() > 0)
				{
					return _responseBuilder.BadRequest(listOfErrors.ToJArray());

				};
				var tickets = _unitOfWork.TicketRepository.Get(x => x.Id == inputModel.Id).FirstOrDefault();
				if (tickets != null)
				{
					
					_unitOfWork.TicketRepository.Update(inputModel);
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
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<TicketsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
