using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShineCoder_Helpdesk.Core.Enums;

namespace ShineCoder_Helpdesk.Core.Models
{
    public class SearchModel
    {
        public  UserTypeEnum UserType { get; set; }
        public int DepartmentId { get; set; }
        public string SearchOption { get; set; }
        public string SearchString { get; set; }
        public int Tkt_Id { get; set; }
        public TicketStatusEnum Status { get; set; }

        public bool ShowAll { get; set; }

	}
}
