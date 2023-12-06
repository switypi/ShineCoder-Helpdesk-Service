using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core.Enums;

namespace ShineCoder_Helpdesk.Core
{
	public interface IResponseBuilder
	{
		JObject BadRequest(JToken data = null, JObject extraData = null);
		JObject BadRequest(string error);
		JObject CreateReponse(ServerResponseCodeEnums code);
		JObject CreateReponse(ServerResponseCodeEnums code, JToken data = null, JObject extraData = null);
		JObject CreateReponseWithError(ServerResponseCodeEnums code, List<string> errors);
		JObject NotFound(JToken data = null, JObject extraData = null);
		JObject NotImplementedError(JToken data = null, JObject extraData = null);
		JObject ServerError(JToken data = null, JObject extraData = null);
		JObject Success(JToken data = null, JObject extraData = null);
		//JObject Success( JObject extraData = null);
		JObject Unauthorized(JToken data = null, JObject extraData = null);
	}
}