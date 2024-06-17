using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core;
using ShineCoder_Helpdesk.Core.Helpers;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Infrastructure.Models;
using ShineCoder_Helpdesk.Repository;

namespace ShineCoder_Helpdesk.Services.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.RDEPARTMENT_SERVICE_API_PREFIX)]
	[ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
	public class DepartmentController : ControllerBase
	{
		private readonly IHttpContextProxy _httpContextProxy;
		private readonly IUnitOfWork _unitOfWork;
		protected readonly IResponseBuilder _responseBuilder;
		private readonly ILogger _logger;
		private readonly IValidator _customerValidator;
		private readonly IMapper _mapper;
		public DepartmentController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
			ILogger<DepartmentController> logger, IValidator customerValidator, IMapper mapper)
		{
			_httpContextProxy = httpContextProxy;
			_unitOfWork = unitOfWork;
			_responseBuilder = responseBuilder;
			_logger = logger;
			_customerValidator = customerValidator;
			_mapper = mapper;
		}
		[HttpGet]
		[Route("GetDepartmentsAsyn")]
		public async Task<JObject> GetDepartmentsAsyn()
		{
			try
			{
				var data = await _unitOfWork.DepartmentRepository.GetAsync();
				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}
		[HttpGet]
		[Route("GetDepartmentByIdAsync")]
		public async Task<JObject> GetDepartmentByIdAsync()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("_Id"));
				
				var data =await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == id);

				return _responseBuilder.Success(data.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message,null);
			}

		}

		[HttpPost]
		[Route("CreateDepartmentAsyn")]
		public async Task<JObject> CreateDepartmentAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<DepartmentModel>();
					var outputModel = _mapper.Map<Department>(inputData);
					_unitOfWork.DepartmentRepository.InsertAsyn(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Department created.");
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
		[Route("DeleteDepartmentAsyn")]
		public async Task<JObject> DeleteDepartmentAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<DepartmentModel>();
					var outputModel = _mapper.Map<Department>(inputData);

					_unitOfWork.DepartmentRepository.DeleteAsync(outputModel.Id);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Department deleted.");
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
		[Route("UpdateDepartmentAsyn")]
		public async Task<JObject> UpdateDepartmentAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<DepartmentModel>();
					var outputModel = _mapper.Map<Department>(inputData);

					_unitOfWork.DepartmentRepository.UpdateAsync(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Department updated.");
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
