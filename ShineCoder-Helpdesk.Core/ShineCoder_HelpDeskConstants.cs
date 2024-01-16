using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core
{
    public class ShineCoder_HelpDeskConstants
    {
        public const string SHINECODERLMS_VERSION = "1.0";
        public const string TICKETS_SERVICE_API_PREFIX = "/Tickets";
		public const string CATEGORY_SERVICE_API_PREFIX = "/Category";
		public const string SUBCATEGORY_SERVICE_API_PREFIX = "/SubCategory";
		public const string AUTHENTICATION_SERVICE_API_PREFIX = "/Authentication";
        public const string ADMIN_SETTING_SERVICE_API_PREFIX = "/AdminSettings";


        public const string INSTRUCTOR_SERVICE_API_PREFIX = "/instructor";
        public const string COURSE_SERVICE_API_PREFIX = "/course";
        public const string COURSECATEGORY_SERVICE_API_PREFIX = "/coursecategory";
        public const string ENROLLMENT_SERVICE_API_PREFIX = "/enrollment";
    }

    public static class ActionMethods
    {
        public const string GET = "GET";
        public const string POST = "POST";
        public const string ACTION = "ACTION";
        public const string DELETE = "DELETE";
        public const string PUT = "PUT";

    }
    public static class CommonConstants
    {
        public const string ACCESS_ALL = "*";
        public const string ACCESS_NONE = "";
        public static MessageText Messages
        {
            get
            {
                return MessageText.GetMessage();
            }
        }
    }

    public static class CommonField
    {
        public const string HTTP_RESPONE_CODE = "code";
        public const string HTTP_RESPONE_MESSAGE = "message";
        public const string HTTP_RESPONE_DATA = "data";
        public const string HTTP_RESPONE_TRANSACTION_ID = "txn_id";
    }
}
