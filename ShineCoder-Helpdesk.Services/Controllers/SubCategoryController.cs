using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core;
using ShineCoder_Helpdesk.Core.Helpers;
using ShineCoder_Helpdesk.Repository;

namespace ShineCoder_Helpdesk.Services.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.SUBCATEGORY_SERVICE_API_PREFIX)]
	[ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
				var id = int.Parse(_httpContextProxy.GetQueryString("CategoryId"));
				var subCategoryData = await _unitOfWork.SubCategorysRepository.GetAsync(x=>x.CategoryId==id && x.Active==true);
				return _responseBuilder.Success(subCategoryData.ToJArray());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return _responseBuilder.BadRequest(ex.Message);
			}

		}
	}
}
