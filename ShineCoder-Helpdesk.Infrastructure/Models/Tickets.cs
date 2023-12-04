using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
    public class Tickets : BaseEntity
    {
        public string Tkt_Desc { get; set; }
        public string Tkt_Number { get; set; }

        public string Tkt_Subject { get; set; }

        public Int32 Tkt_RequestUserId { get; set; }

        public string Tkt_RequestUserName { get; set; }
        public Int32 Tkt_AssignedUser { get; set; }
        public string Tkt_AssignedUserName { get; set; }
        public DateTime Tkt_DueDate { get; set; }

        public Ticket_Status Tkt_Status { get; set; }

        public Ticket_Priorities Tkt_Priorities { get; set; }

        public Location Tkt_Location { get; set; }

        public Department Tkt_Department { get; set; }
       // public Category Tkt_Category { get; set; }
        public SubCategory Tkt_SubCategory { get; set;}
        public RequestType Tkt_RequestType { get; set; }

        public Ticket_Mode Ticket_Mode { get; set; }

        



    }
}
