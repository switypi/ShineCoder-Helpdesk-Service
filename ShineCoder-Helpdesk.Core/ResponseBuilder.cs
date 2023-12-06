using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core.Enums;

namespace ShineCoder_Helpdesk.Core
{
	public class ResponseBuilder : IResponseBuilder
	{


		public JObject Success(JToken data = null, JObject extraData = null)
		{
			return CreateReponse(ServerResponseCodeEnums.SUCCESS, data, extraData);
		}

		//public JObject Success(JObject extraData = null)
		//{
		//	return CreateReponse(ServerResponseCodeEnums.SUCCESS, extraData);
		//}

		public JObject BadRequest(string error)
		{
			var errorobj = new JObject();
			errorobj["error"] = error;
			return BadRequest(errorobj);
		}
		public JObject BadRequest(JToken data = null, JObject extraData = null)
		{
			return CreateReponse(ServerResponseCodeEnums.BAD_REQUEST, data, extraData);
		}
		public JObject Unauthorized(JToken data = null, JObject extraData = null)
		{
			return CreateReponse(ServerResponseCodeEnums.UNAUTHORIZED, data, extraData);
		}

		public JObject NotFound(JToken data = null, JObject extraData = null)
		{
			return CreateReponse(ServerResponseCodeEnums.RESOURCE_NOT_FOUND, data, extraData);
		}
		public JObject NotImplementedError(JToken data = null, JObject extraData = null)
		{
			return CreateReponse(ServerResponseCodeEnums.NOT_IMPLEMENTED, data, extraData);
		}
		public JObject ServerError(JToken data = null, JObject extraData = null)
		{
			return CreateReponse(ServerResponseCodeEnums.SERVER_ERROR, data, extraData);
		}
		public JObject CreateReponse(ServerResponseCodeEnums code, JToken data = null, JObject extraData = null)
		{
			var response = CreateResponseObject(code);
			if (extraData != null)
			{
				foreach (var item in extraData)
				{
					response[item.Key] = item.Value;
				}
			}
			if (data != null)
			{
				response[CommonField.HTTP_RESPONE_DATA] = data;
			}

			return response;
		}

		public JObject CreateReponse(ServerResponseCodeEnums code)
		{
			var response = CreateResponseObject(code);

			//AddDebugData(response);
			return response;
		}
		public JObject CreateReponseWithError(ServerResponseCodeEnums code, List<string> errors)
		{
			if (code == ServerResponseCodeEnums.SUCCESS || code == ServerResponseCodeEnums._200_OK)
			{
				throw new NotSupportedException($"Unsupported response code {code} for error response");
			}
			var response = CreateReponse(code);
			if (errors != null && errors.Any())
			{
				var errorobj = new JArray();
				foreach (var error in errors)
				{
					errorobj.Add(error);
				}
				response["errors"] = errorobj;
			}
			return response;

		}
		private JObject CreateResponseObject(ServerResponseCodeEnums code)
		{
			JObject response = new JObject();
			response[CommonField.HTTP_RESPONE_CODE] = (int)code;
			response[CommonField.HTTP_RESPONE_MESSAGE] ="" ;

			return response;
		}
	}
}
