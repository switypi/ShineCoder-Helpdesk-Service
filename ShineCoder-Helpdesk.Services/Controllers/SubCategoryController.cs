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
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Infrastructure.Models;
using ShineCoder_Helpdesk.Repository;

namespace ShineCoder_Helpdesk.Services.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.SUBCATEGORY_SERVICE_API_PREFIX)]
	[ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class SubCategoryController : ControllerBase
	{
		private readonly IHttpContextProxy _httpContextProxy;
		private readonly IUnitOfWork _unitOfWork;
		protected readonly IResponseBuilder _responseBuilder;
		private readonly ILogger _logger;
		private readonly IValidator _customerValidator;
		private readonly IMapper _mapper;
		public SubCategoryController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
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
		[Route("GetSubCategoriesByCategoryId")]
		public async Task<JObject> GetSubCategoriesByCategoryIdAsync()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("_categoryId"));
				var subCategoryData = await _unitOfWork.SubCategorysRepository.GetAsync(x => x.CategoryId == id && x.Active == true);
				return _responseBuilder.Success(subCategoryData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}
		[HttpGet]
		[Route("GetSubCategories")]
		public async Task<JObject> GetSubCategories()
		{
			try
			{
				var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
				var subCategoryData = (from item in db.SubCategories
									   join item2 in db.Categories on item.CategoryId equals item2.Id
									   select new SubCategoryModel()
									   {
										   Id = item.Id,
										   Active = item.Active.Value,
										   CategoryId = item.CategoryId,
										   Description = item.Description,
										   IsDefault = item.IsDefault
									   ,
										   Name = item.Name,
										   Category = item2.Name
									   }).ToList();

				return _responseBuilder.Success(subCategoryData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}

		[HttpGet]
		[Route("GetSubCategoriesById")]
		public async Task<JObject> GetSubCategoriesById()
		{
			try
			{
				var id = int.Parse(_httpContextProxy.GetQueryString("_Id"));
				var db = _unitOfWork.GetDbContext as HelpdeskDbContext;
				var subCategoryData =await _unitOfWork.SubCategorysRepository.GetAsync(x => x.Id == id);

				return _responseBuilder.Success(subCategoryData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}

		[HttpPost]
		[Route("CreateSubCategoryAsync")]
		public async Task<JObject> CreateSubCategoryAsync()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var subCategoryModel = _httpContextProxy.GetRequestBody<SubCategoryModel>();
					var listOfErrors = _customerValidator.Validate(subCategoryModel);

					if (listOfErrors.Count() > 0)
					{
						return _responseBuilder.BadRequest(listOfErrors.ToJArray());

					};
					var subCategoryData = _mapper.Map<SubCategory>(subCategoryModel);
					_unitOfWork.SubCategorysRepository.InsertAsyn(subCategoryData);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Sub-Category create successfully.");
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
		[Route("DeleteSubCategoryAsyn")]
		public async Task<JObject> DeleteSubCategoryAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<SubCategoryModel>();
					var outputModel = _mapper.Map<SubCategory>(inputData);

					_unitOfWork.SubCategorysRepository.DeleteAsync(outputModel.Id);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Sub-Category deleted.");
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
		[Route("UpdateSubCategoryAsyn")]
		public async Task<JObject> UpdateSubCategoryAsyn()
		{
			IDbContextTransaction trans = null;
			using (trans = _unitOfWork.GetDbTransaction)
			{
				try
				{
					var inputData = _httpContextProxy.GetRequestBody<SubCategoryModel>();
					var outputModel = _mapper.Map<SubCategory>(inputData);

					_unitOfWork.SubCategorysRepository.UpdateAsync(outputModel);
					await _unitOfWork.SaveAsync();
					await trans.CommitAsync();
					return _responseBuilder.Success("Sub-Category updated.");
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
