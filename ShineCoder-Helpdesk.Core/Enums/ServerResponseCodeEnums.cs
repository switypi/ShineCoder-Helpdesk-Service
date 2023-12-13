using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Enums
{
	public enum ServerResponseCodeEnums
	{
		SUCCESS = 200,
		RESOURCE_NOT_FOUND = 404,
		BAD_REQUEST = 400,
		SERVER_ERROR = 500,
		UNAUTHORIZED = 401,
		NOT_IMPLEMENTED = 503,

	}
}
