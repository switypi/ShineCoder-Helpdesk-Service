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
	[Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.TICKET_ATTACHMENT_SERVICE_API_PREFIX)]
	[ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class TicketAttachmentController : ControllerBase
	{
		private readonly IHttpContextProxy _httpContextProxy;
		private readonly IUnitOfWork _unitOfWork;
		protected readonly IResponseBuilder _responseBuilder;
		private readonly ILogger _logger;
		private readonly IValidator _customerValidator;
		private readonly IMapper _mapper;
		public TicketAttachmentController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
		   ILogger<AdminSettingsController> logger, IValidator customerValidator, IMapper mapper)
		{
			_httpContextProxy = httpContextProxy;
			_unitOfWork = unitOfWork;
			_responseBuilder = responseBuilder;
			_logger = logger;
			_customerValidator = customerValidator;
			_mapper = mapper;
		}

		[HttpDelete]
		[Route("DeleteAttachment")]
		public async Task<JObject> DeleteAttachment()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					
					var attachmentId = int.Parse(_httpContextProxy.GetQueryString("_id"));
					//var attachment = _unitOfWork.TicketAttachmentRepository.GetAsync(x => x.Id == attachmentId).Result.FirstOrDefault();
					if (attachmentId != null || attachmentId > 0)
					{
						_unitOfWork.TicketAttachmentRepository.DeleteAsync(attachmentId);
						await _unitOfWork.SaveAsync();
						await trans.CommitAsync();
						return _responseBuilder.Success("Tickets updated.");
					}
					else
					{
						return _responseBuilder.Success($"Could not delete attachment with Id = {attachmentId}");
					}


				}
				catch (Exception ex)
				{
					await trans.RollbackAsync();
					_logger.LogError(ex.Message);
					return _responseBuilder.BadRequest(ex.Message,null);
				}
			}
		}


	}
}
