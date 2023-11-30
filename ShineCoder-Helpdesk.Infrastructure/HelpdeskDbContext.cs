using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Infrastructure
{
	public class HelpdeskDbContext : DbContext, IHelpdeskDbContext
	{
		public DbSet<Tickets> Students { get; set; }
		public DbSet<Ticket_Issues> Cources { get; set; }
		public DbSet<Ticket_Priorities> CourceCategories { get; set; }
		public DbSet<Ticket_Solutions> Enrollments { get; set; }
		public DbSet<Ticket_Status> Instructors { get; set; }
		public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options)
		   : base(options)
		{ }
		public async Task<int> SaveChanges()
		{
			return await base.SaveChangesAsync();
		}
	}
}
