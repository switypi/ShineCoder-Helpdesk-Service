using Newtonsoft.Json.Linq;

namespace ShineCoder_Helpdesk.Core
{
	public interface IHttpContextProxy
	{
		string ContentType { get; set; }
		DateTime InitDateTime { get; }
		byte[] Response { get; }
		int ResponseStatusCode { get; }
		string ResponseStatusMessage { get; }
		string SessionID { get; }
		string TransactionId { get; }

		 string UserName { get; }

		string GetFormData(string key);
		Dictionary<string, string> GetHeaders();
		string GetHttpMethod();
		string GetMimeType(string fileName);
		string GetQueryString();
		string GetQueryString(string key);
		string GetRequestBody();
		T GetRequestBody<T>();
		string GetRequestHeader(string key);
		string GetResponseHeader(string key);
		string GetURIAbsolutePath();
		void SetResponse(byte[] data);
		void SetResponse(int statusCode, JObject data = null);
		void SetResponse(int statusCode, byte[] data);
		void SetResponse(int statusCode, string data);
		void SetResponse(string data);
		void SetTenantId(long tenant_id);
		void UnloadAppDomain();
	}
}