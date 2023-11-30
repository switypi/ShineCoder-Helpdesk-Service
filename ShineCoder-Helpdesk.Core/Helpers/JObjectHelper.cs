using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ShineCoder_Helpdesk.Core.Helpers
{
	public static class JObjectHelper
	{
		public static T Deserialize<T>(JObject data)
		{
			return Deserialize<T>(data.ToString());
		}

		public static T Deserialize<T>(string data)
		{
			return JsonConvert.DeserializeObject<T>(data);
		}

		public static JObject Serialize<T>(T data)
		{
			string varData = JsonConvert.SerializeObject(data);
			return JObject.Parse(varData);
		}

		public static JArray GetJArrayFromFile(string filePath)
		{
			JArray arrData = new JArray();
			var filedata = File.ReadAllText(filePath);
			arrData = JArray.Parse(filedata);
			return arrData;
		}
		public static JArray GetJArrayFromString(string data)
		{
			try
			{
				return GetJArray(data);
			}
			catch (Exception ex)
			{
				return GetJArray(data.Remove(0, 1));
			}
		}

		private static JArray GetJArray(string data)
		{
			JArray arrData = new JArray();
			arrData = JArray.Parse(data);
			return arrData;
		}

		public static JObject GetJObjectFromFile(string filePath)
		{
			JObject jobjData = new JObject();
			var filedata = File.ReadAllText(filePath);
			jobjData = JObject.Parse(filedata);
			return jobjData;
		}

		public static void WriteJSONData(string filePath, JToken data)
		{
			File.WriteAllText(filePath, data.ToString());
		}

		public static JObject Marge(JObject obj1, JObject obj2, MergeArrayHandling mergeType)
		{
			obj1.Merge(obj2, new JsonMergeSettings
			{
				MergeArrayHandling = mergeType
			});
			return obj1;
		}



		private static string GetTextData(string path)
		{
			return File.ReadAllText(path);
		}
		public static JObject ToJObject(this object obj)
		{
			return JObject.Parse(JsonConvert.SerializeObject(obj));
		}
		public static JArray ToJArray<T>(this List<T> obj)
		{
			return JArray.Parse(JsonConvert.SerializeObject(obj));
		}
		public static JArray ToJArray<T>(this IEnumerable<T> obj)
		{
			return JArray.Parse(JsonConvert.SerializeObject(obj));
		}
	}
}
