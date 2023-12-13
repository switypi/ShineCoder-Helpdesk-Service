using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace ShineCoder_Helpdesk.Core
{
	public partial class HttpContextProxy : IHttpContextProxy
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		private long _tenant_Id;
		public HttpContextProxy(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		//public Dictionary<string, string> ResponseHeaders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public int ResponseStatusCode => throw new NotImplementedException();

		public string ResponseStatusMessage => throw new NotImplementedException();

		public byte[] Response => throw new NotImplementedException();

		public string ContentType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public string SessionID => throw new NotImplementedException();

		public DateTime InitDateTime => throw new NotImplementedException();

		public string TransactionId => throw new NotImplementedException();

		public string UserName
		{
			get
			{
				return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
			}
		}


		public string GetFormData(string key)
		{
			throw new NotImplementedException();
		}

		public string GetRequestHeader(string key)
		{
			if (_httpContextAccessor.HttpContext != null)
			{
				return _httpContextAccessor.HttpContext.Request.Headers[key];
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// This Method Sets Tenant ID from Tenant KEY from API Base Class
		/// </summary>
		/// <returns></returns>

		public string GetResponseHeader(string key)
		{
			if (_httpContextAccessor.HttpContext != null)
			{
				return _httpContextAccessor.HttpContext.Request.Headers[key];
			}
			else
			{
				return null;
			}
		}

		public Dictionary<string, string> GetHeaders()
		{
			var header = new Dictionary<string, string>();
			if (_httpContextAccessor.HttpContext != null)
			{
				foreach (var h in _httpContextAccessor.HttpContext.Request.Headers)
				{
					header.Add(h.Key, h.Value);
				}
			}
			return header;
		}

		public string GetHttpMethod()
		{
			if (_httpContextAccessor.HttpContext != null)
			{
				return _httpContextAccessor.HttpContext.Request.Method;
			}
			else
			{
				return string.Empty;
			}
		}

		public string GetMimeType(string fileName)
		{
			throw new NotImplementedException();
		}

		public string GetQueryString(string key)
		{
			if (_httpContextAccessor.HttpContext != null)
			{
				return _httpContextAccessor.HttpContext.Request.Query[key];
			}
			else
			{
				return null;
			}
		}
		public string GetQueryString()
		{
			if (_httpContextAccessor.HttpContext != null)
			{
				return _httpContextAccessor.HttpContext.Request.QueryString.Value;
			}
			else
			{
				return null;
			}
		}

		public string GetRequestBody()
		{
			if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Request.Body != null)
			{
				var requestBody = new StreamReader(_httpContextAccessor.HttpContext.Request.Body).ReadToEndAsync().GetAwaiter().GetResult();
				return requestBody;
			}
			return null;
		}

		public T GetRequestBody<T>()
		{
			string body = GetRequestBody();
			try
			{
				if (!string.IsNullOrEmpty(body))
				{
					return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(body);
				}
				else
				{
					return default;
				}
			}
			catch (Exception ex)
			{
				//logger.Error(string.Format("Error while converting data [{0}], Error :  {1}", body, ex.Message), ex);
				return default;
			}
		}

		public string GetURIAbsolutePath()
		{
			if (_httpContextAccessor.HttpContext != null)
			{
				return _httpContextAccessor.HttpContext.Request.Path.ToString().ToLower();
			}
			else
			{
				return null;
			}
		}
		public void SetTenantId(long tenant_id)
		{
			_tenant_Id = tenant_id;
		}

		public void SetResponse(int statusCode, JObject data = null)
		{
			throw new NotImplementedException();
		}

		public void SetResponse(int statusCode, string data)
		{
			throw new NotImplementedException();
		}

		public void SetResponse(int statusCode, byte[] data)
		{
			throw new NotImplementedException();
		}

		public void SetResponse(string data)
		{
			throw new NotImplementedException();
		}

		public void SetResponse(byte[] data)
		{
			throw new NotImplementedException();
		}

		public void UnloadAppDomain()
		{
			throw new NotImplementedException();
		}


	}
}
