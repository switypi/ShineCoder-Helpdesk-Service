using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Infrastructure.Models;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Http;
using Azure.Identity;
using System.Security.Claims;

namespace ShineCoder_Helpdesk.Infrastructure
{
	public class HelpdeskDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Int32>, IHelpdeskDbContext
	{
		private IHttpContextAccessor _httpContextAccessor;
		public DbSet<Tickets> Tickets { get; set; }
		public DbSet<Ticket_Mode> Ticket_Modes { get; set; }
		public DbSet<Ticket_Priorities> Ticket_Priorities { get; set; }
		public DbSet<Ticket_Solutions> Ticket_Solutions { get; set; }
		public DbSet<Ticket_Status> Ticket_Status { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Location> Locations { get; set; }

		public DbSet<Product> Products { get; set; }

        public DbSet<Ticket_Impact> Ticket_Impacts { get; set; }
        public DbSet<Ticket_Urgency> Ticket_Urgencies { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }


        public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options, IHttpContextAccessor httpContextAccessor)
		   : base(options)
		{
			_httpContextAccessor = httpContextAccessor;
		}


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasDefaultSchema("Dbo");

			builder.Entity<ApplicationUser>(entity =>
			{
				entity.ToTable(name: "User", "Identity");
				entity.HasKey(u => u.Id);
				//entity.Property(u => u.Id).HasDefaultValue(1);
			});
			builder.Entity<ApplicationRole>(entity =>
			{
				entity.ToTable(name: "Roles", "Identity");
                entity.HasKey(u => u.Id);
                //entity.Property(u => u.Id).HasDefaultValue(1);

			});
			builder.Entity<IdentityUserRole<Int32>>(entity =>
			{
				entity.ToTable("UserRoles", "Identity");
			});
			builder.Entity<IdentityUserClaim<Int32>>(entity =>
			{
				entity.ToTable("UserClaims", "Identity");
			});
			builder.Entity<IdentityUserLogin<Int32>>(entity =>
			{
				entity.ToTable("UserLogins", "Identity");
			});
			builder.Entity<IdentityRoleClaim<Int32>>(entity =>
			{
				entity.ToTable("RoleClaims", "Identity");
			});
			builder.Entity<IdentityUserToken<Int32>>(entity =>
			{
				entity.ToTable("UserTokens", "Identity");
			});

			builder.Entity<Ticket_Status>().HasData(
			new Ticket_Status { Id = 1, Name = "New",Description="New ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Status { Id = 2, Name = "Open", Description = "Open ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Status { Id = 3, Name = "Closed", Description = "Closed ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Status { Id = 4, Name = "Resolved", Description = "Resolved ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Status { Id = 5, Name = "Assigned", Description = "Assigned ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });
			builder.Entity<Ticket_Priorities>().HasData(
			new Ticket_Priorities { Id = 1, Name = "Low",Description = "Low priority ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Priorities { Id = 2, Name = "High", Description = "High priority ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Priorities { Id = 3, Name = "Medium", Description = "Medium priority ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
            new Ticket_Priorities { Id = 4, Name = "Normal", Description = "Normal priority ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });

            builder.Entity<Ticket_Urgency>().HasData(
            new Ticket_Urgency { Id = 1, Name = "Low", Description = "Low Urgency", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Urgency { Id = 2, Name = "High", Description = "High urgency", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Urgency { Id = 3, Name = "Normal", Description = "Normal urgency", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
            new Ticket_Urgency { Id = 4, Name = "Urgent", Description = "Urgent", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });

            builder.Entity<Ticket_Impact>().HasData(
            new Ticket_Urgency { Id = 1, Name = "Low", Description = "Low impact ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
            new Ticket_Urgency { Id = 2, Name = "High", Description = "High impact ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
            new Ticket_Urgency { Id = 3, Name = "Normal", Description = "Normal impact ticket", CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });
         


            builder.Entity<ApplicationRole>().HasData(
			new ApplicationRole { Id = 1, RoleName = "Admin", Name = "admin", IsActive = true, IsAgent = false, IsClient = false },
			new ApplicationRole { Id = 2, RoleName = "Client", Name = "Client", IsActive = true, IsAgent = false, IsClient = true },
			new ApplicationRole { Id = 3, RoleName = "Agent", Name = "Agent", IsActive = true, IsAgent = true, IsClient = false });


        }

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{


			if (_httpContextAccessor.HttpContext.User.Identity.Name != null) // During User registration Identity is not set.
			{
				string userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
				ChangeTracker.SetAuditProperties(userName);
                
            }

            return await base.SaveChangesAsync();
        }
	}
}
