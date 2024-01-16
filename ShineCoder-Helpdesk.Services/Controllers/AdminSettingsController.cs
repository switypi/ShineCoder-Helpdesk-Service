using System.Diagnostics;
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
    [Route("api/v{version:apiVersion}" + ShineCoder_HelpDeskConstants.ADMIN_SETTING_SERVICE_API_PREFIX)]
    [ApiVersion(ShineCoder_HelpDeskConstants.SHINECODERLMS_VERSION)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdminSettingsController : ControllerBase
    {
        private readonly IHttpContextProxy _httpContextProxy;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IResponseBuilder _responseBuilder;
        private readonly ILogger _logger;
        private readonly IValidator _customerValidator;
        private readonly IMapper _mapper;
        public AdminSettingsController(IHttpContextProxy httpContextProxy, IUnitOfWork unitOfWork, IResponseBuilder responseBuilder,
            ILogger<AdminSettingsController> logger, IValidator customerValidator, IMapper mapper)
        {
            _httpContextProxy = httpContextProxy;
            _unitOfWork = unitOfWork;
            _responseBuilder = responseBuilder;
            _logger = logger;
            _customerValidator = customerValidator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetRequestTypes")]
        public async Task<JObject> GetCategoriesAsyn()
        {
            try
            {
                var categoryData = await _unitOfWork.RequestTypeRepository.GetAsync(x => x.Active == true);
                return _responseBuilder.Success(categoryData.ToJArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _responseBuilder.BadRequest(ex.Message);
            }

        }
    }
}
