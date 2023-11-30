using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Enums
{
	public enum ServerResponseCodeEnums
	{
		_200_OK = 200,
		RESOURCE_NOT_FOUND = 404,
		BAD_REQUEST = 400,
		SERVER_ERROR = 500,
		UNAUTHORIZED = 501,
		NOT_IMPLEMENTED = 503,


		SUCCESS = 1,

	}
}
