using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Infrastructure
{
	public interface IHelpdeskDbContext
	{
         DbSet<Tickets> Tickets { get; set; }
         DbSet<Ticket_Mode> Ticket_Modes { get; set; }
         DbSet<Ticket_Priorities> Ticket_Priorities { get; set; }
         DbSet<Ticket_Solutions> Ticket_Solutions { get; set; }
         DbSet<Ticket_Status> Ticket_Status { get; set; }
         DbSet<Department> Departments { get; set; }
         DbSet<SubCategory> SubCategories { get; set; }
         DbSet<Category> Categories { get; set; }
         DbSet<Location> Locations { get; set; }

         DbSet<RequestType> RequestTypes { get; set; }
		 DbSet<Ticket_Level> Ticket_Levels { get; set; }

		 DbSet<Product> Products { get; set; }

		 DbSet<Ticket_Impact> Ticket_Impacts { get; set; }
		 DbSet<Ticket_Urgency> Ticket_Urgencies { get; set; }


	}
}