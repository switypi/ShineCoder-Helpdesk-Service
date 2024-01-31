﻿using Microsoft.AspNetCore.Mvc;
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
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
		[Route("GetTicketsByIdAsync")]
		public async Task<JObject> GetTicketsByIdAsync()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("_TicketId"));
				var data = GetTicketDetails(id, "");

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
				var ticketData = await _unitOfWork.TicketRepository.GetAsync(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Assigned);
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
				var ticketData = await _unitOfWork.TicketRepository.GetAsync(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.New);
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
					outputModel.Active = true;
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
					var tickets = _unitOfWork.TicketRepository.GetAsync(x => x.Id == inputModel.Id).Result.FirstOrDefault();

					if (tickets != null)
					{
						tickets.TicketLevelId = inputModel.TicketLevelId;
						tickets.TicketPriorityId = inputModel.TicketPriorityId;
						tickets.TicketStatusId = inputModel.TicketStatusId;
						tickets.Ticket_Desc = inputModel.Tkt_Desc;
						tickets.Ticket_ModeId = inputModel.Ticket_ModeId;
						tickets.Ticket_Subject = inputModel.Tkt_Subject;
						tickets.Tkt_AssignedUserId = inputModel.Tkt_AssignedUserId;
						tickets.Tkt_CategoryId = inputModel.Tkt_CategoryId;
						tickets.Tkt_DepartmentId = inputModel.Tkt_DepartmentId;
						tickets.Tkt_DueDate = inputModel.Tkt_DueDate;

						tickets.Ticket_Attachments = new List<Ticket_Attachments>();

						foreach (var item in inputModel.Ticket_Attachments)
						{
							if (item.ImageBytes != null)
							{
								tickets.Ticket_Attachments.Add(new Ticket_Attachments { TicketId = tickets.Id, ImageBytes = item.ImageBytes, Extension = item.Extension, Name = item.Name });
							}
						}

						_unitOfWork.TicketRepository.UpdateAsync(tickets);
						await _unitOfWork.SaveAsync();
						await trans.CommitAsync();
					}

					return _responseBuilder.Success("Tickets updated.");
				}
				catch (Exception ex)
				{
					await trans.RollbackAsync();
					_logger.LogError(ex.Message);
					return _responseBuilder.BadRequest(ex.Message);
				}
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

		[HttpGet]
		[Route("GetAllTickets")]
		public async Task<JObject> GettAllTickets()
		{
			try
			{
				var status = _httpContextProxy.GetQueryString("_ticketStatus");


				var data = GetTicketDetails(status: status);

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
		[Route("GetImage")]
		public async Task<JObject> GetImage()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("Id"));
				var ticketData = await _unitOfWork.TicketAttachmentRepository.GetAsync(x => x.Active == true && x.Id == id);
				return _responseBuilder.Success(ticketData.FirstOrDefault().ImageBytes);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("AssignTicket")]
		public  async Task<JObject> AssignTicket()
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
					var tickets = _unitOfWork.TicketRepository.GetAsync(x => x.Id == inputModel.Id).Result.FirstOrDefault();

					if (tickets != null)
					{
						
						tickets.TicketStatusId =(int) TicketStatusEnum.Open;
						tickets.Tkt_AssignedUserId = inputModel.Tkt_AssignedUserId;
					
						_unitOfWork.TicketRepository.UpdateAsync(tickets);
						await _unitOfWork.SaveAsync();
						await trans.CommitAsync();
					}

					return _responseBuilder.Success("Tickets updated.");
				}
				catch (Exception ex)
				{
					await trans.RollbackAsync();
					_logger.LogError(ex.Message);
					return _responseBuilder.BadRequest(ex.Message);
				}
			}
		}



		private List<TicketsModel> GetTicketDetails(Int32? Tkt_Id = null, string status = null)
		{
			try
			{
				List<TicketsModel> result = null;
				IQueryable<Tickets> tksQuery = null;
				var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
				//var userRoles = db.UserRoles;
				if (Tkt_Id != null)
					tksQuery = db.Tickets.Where(x => x.Active == true && x.Id == Tkt_Id);
				else
				{
					if (status == Enum.GetName(typeof(TicketStatusEnum), TicketStatusEnum.New))
						tksQuery = db.Tickets.Where(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.New);
					else if (status == Enum.GetName(typeof(TicketStatusEnum), TicketStatusEnum.Assigned))
						tksQuery = db.Tickets.Where(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Open );
					else if (status == Enum.GetName(typeof(TicketStatusEnum), TicketStatusEnum.Pending))
						tksQuery = db.Tickets.Where(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Open);
					else if (status == Enum.GetName(typeof(TicketStatusEnum), TicketStatusEnum.Closed))
						tksQuery = db.Tickets.Where(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Closed);
					else if (status == Enum.GetName(typeof(TicketStatusEnum), TicketStatusEnum.OverDue))
						tksQuery = db.Tickets.Where(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Open && x.Tkt_DueDate < DateTime.Today);
					else if (status == Enum.GetName(typeof(TicketStatusEnum), TicketStatusEnum.DueToday))
						tksQuery = db.Tickets.Where(x => x.Active == true && x.TicketStatusId == (int)TicketStatusEnum.Open && x.Tkt_DueDate== DateTime.Today);
					else 
						tksQuery = db.Tickets.Where(x => x.Active == true);
				}


				var data = (from x in tksQuery
							join y in db.Categories on x.Tkt_CategoryId equals y.Id
							join y1 in db.SubCategories.Where(qq => qq.Active == true) on x.Tkt_SubCategoryId equals y1.Id
							join z in db.Ticket_Status.Where(qq => qq.Active == true) on x.TicketStatusId equals z.Id
							join v in db.Departments.Where(qq => qq.Active == true) on x.Tkt_DepartmentId equals v.Id
							join w in db.Locations.Where(qq => qq.Active == true) on x.Tkt_LocationId equals w.Id
							join q in db.Ticket_Impacts.Where(qq => qq.Active == true) on x.Tkt_ImpactId equals q.Id
							join r in db.Ticket_Priorities.Where(qq => qq.Active == true) on x.TicketPriorityId equals r.Id
							join s in db.RequestTypes.Where(qq => qq.Active == true) on x.Tkt_RequestTypeId equals s.Id
							join t in db.Ticket_Modes.Where(qq => qq.Active == true) on x.Ticket_ModeId equals t.Id
							join u in db.Ticket_Levels.Where(qq => qq.Active == true) on x.TicketLevelId equals u.Id
							join o in db.Users on x.Tkt_RequestUserId equals o.Id
							from p in db.Users.Where(m => m.Id == x.Tkt_AssignedUserId).DefaultIfEmpty()
								// from ta in db.Attachments.Where(cv=>cv.TicketId==x.Id).DefaultIfEmpty()

							select new TicketsModel
							{
								Id = x.Id,
								TicketLevelId = x.TicketLevelId,
								TicketPriorityId = x.TicketPriorityId,
								TicketStatusId = x.TicketStatusId,
								Ticket_ModeId = x.Ticket_ModeId,
								Tkt_CategoryId = x.Tkt_CategoryId,
								Tkt_DepartmentId = x.Tkt_DepartmentId,
								Tkt_Desc = x.Ticket_Desc,
								Tkt_ImpactId = x.Tkt_ImpactId,
								Tkt_DueDate = x.Tkt_DueDate,
								Tkt_LocationId = x.Tkt_LocationId,
								Tkt_Number = x.Tkt_Number,
								Tkt_RequestTypeId = x.Tkt_RequestTypeId,
								Tkt_RequestUserId = x.Tkt_RequestUserId.Value,
								Tkt_AssignedUserId = x.Tkt_AssignedUserId,
								Tkt_SubCategoryId = x.Tkt_SubCategoryId,

								Tkt_RequestType = s.Name,
								Tkt_Priority = r.Name,
								Tkt_Department = v.Name,
								Tkt_Category = y.Name,
								Tkt_Imapct = q.Name,
								Tkt_Level = u.Name,
								Tkt_Mode = t.Name,
								Tkt_Requester = o.FirstName + " " + o.LastName,
								Tkt_Subcategory = y1.Name,
								Tkt_Subject = u.Name,
								Tkt_AssignedUser = p == null ? null : p.FirstName + " " + p.LastName,
								Tkt_location = w.Name,
								Tkt_CreatedDate = x.CreatedDate.Value,
								Tkt_Status = z.Name,
								//Ticket_Attachments = ,//  new List<Ticket_Attachments> { new Ticket_Attachments { Id = 1, Name = "1" } },



							}).ToList();

				var atch = (from x in db.Ticket_Attachments.AsEnumerable()
							join y in data on x.TicketId equals y.Id
							where x.Active == true
							select new Ticket_Attachments { Id = x.Id, TicketId = x.TicketId, Name = x.Name }).ToList();

				data.ForEach(x => { x.Ticket_Attachments = atch.Where(c => c.TicketId == x.Id).ToList(); });

				return data.ToList();


			}
			catch (Exception ex)
			{

				_logger.LogError(ex.Message);
				throw ex;
			}
		}

	}
}
