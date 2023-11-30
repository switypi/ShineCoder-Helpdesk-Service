using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Infrastructure
{
	public interface IHelpdeskDbContext
	{
		DbSet<Ticket_Priorities> CourceCategories { get; set; }
		DbSet<Ticket_Issues> Cources { get; set; }
		DbSet<Ticket_Solutions> Enrollments { get; set; }
		DbSet<Ticket_Status> Instructors { get; set; }
		DbSet<Tickets> Students { get; set; }

		Task<int> SaveChanges();
	}
}