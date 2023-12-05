using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Infrastructure
{
	public class HelpdeskDbContext : IdentityDbContext<ApplicationUser>, IHelpdeskDbContext
	{
		public DbSet<Tickets> Tickets { get; set; }
		public DbSet<Ticket_Mode> Ticket_Modes { get; set; }
		public DbSet<Ticket_Priorities> Ticket_Priorities { get; set; }
		public DbSet<Ticket_Solutions> Ticket_Solutions { get; set; }
		public DbSet<Ticket_Status> Ticket_Status { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Location> Locations { get; set; }

		public DbSet<RequestType> RequestTypes { get; set; }
		public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options)
		   : base(options)
		{ }
		public async Task<int> SaveChanges()
		{
			return await base.SaveChangesAsync();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasDefaultSchema("Dbo");

			builder.Entity<ApplicationUser>(entity =>
			{
				entity.ToTable(name: "User","Identity");
			});
			builder.Entity<ApplicationRole>(entity =>
			{
				entity.ToTable(name: "Role", "Identity");
			});
			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable("UserRoles", "Identity");
			});
			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.ToTable("UserClaims", "Identity");
			});
			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable("UserLogins", "Identity");
			});
			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.ToTable("RoleClaims", "Identity");
			});
			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.ToTable("UserTokens", "Identity");
			});
		}
	}
}
