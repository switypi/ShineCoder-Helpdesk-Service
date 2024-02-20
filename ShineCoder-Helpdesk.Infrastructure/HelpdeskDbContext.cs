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
using Microsoft.AspNetCore.Server.IISIntegration;

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

		public DbSet<Ticket_Level> Ticket_Levels { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Ticket_Impact> Ticket_Impacts { get; set; }
		public DbSet<Ticket_Urgency> Ticket_Urgencies { get; set; }
		public DbSet<RequestType> RequestTypes { get; set; }
		public DbSet<Ticket_Attachments> Ticket_Attachments { get; set; }
		

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

			builder.Entity<Tickets>(entity => { entity.Property(c => c.Tkt_Number).HasComputedColumnSql("('SC-'+right(replicate('0',(5))+CONVERT([varchar],[Id]),(5)))"); });

			builder.Entity<Ticket_Status>().HasData(
			new Ticket_Status { Id = 1, Name = "New", Description = "New ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Status { Id = 2, Name = "Open", Description = "Open ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Status { Id = 3, Name = "Closed", Description = "Closed ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Status { Id = 4, Name = "Resolved", Description = "Resolved ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });
			//new Ticket_Status { Id = 5, Name = "Assigned", Description = "Assigned ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });
			builder.Entity<Ticket_Priorities>().HasData(
			new Ticket_Priorities { Id = 1, Name = "Low", Description = "Low priority ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Priorities { Id = 2, Name = "High", Description = "High priority ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Priorities { Id = 3, Name = "Medium", Description = "Medium priority ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Priorities { Id = 4, Name = "Normal", Description = "Normal priority ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });

			builder.Entity<Ticket_Urgency>().HasData(
			new Ticket_Urgency { Id = 1, Name = "Low", Description = "Low Urgency", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Urgency { Id = 2, Name = "High", Description = "High urgency", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Urgency { Id = 3, Name = "Normal", Description = "Normal urgency", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Urgency { Id = 4, Name = "Urgent", Description = "Urgent", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });

			builder.Entity<Ticket_Impact>().HasData(
			new Ticket_Impact { Id = 1, Name = "Low", Description = "Low impact ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Impact { Id = 2, Name = "High", Description = "High impact ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now },
			new Ticket_Impact { Id = 3, Name = "Normal", Description = "Normal impact ticket", Active = true, CreatedBy = "admin", UpdatedBy = "", CreatedDate = DateTime.Now });

			builder.Entity<RequestType>().HasData(new RequestType { Active = true, Id = 1, IsDefault = true, Description = "Service requests", Name = "Service request" });
			builder.Entity<Ticket_Mode>().HasData(
				new Ticket_Mode { Active = true, Id = 1, IsDefault = true, Description = "Website", Name = "WebSite" },
				new Ticket_Mode { Active = true, Id = 2, Name = "Email", Description = "Email", IsDefault = true },
				new Ticket_Mode { Active = true, Id = 3, Name = "Phone", Description = "Phone", IsDefault = true }
			);
			//builder.Entity<Ticket_Level>().HasData(
			//	new Ticket_Level { Active = true, Id = 1, IsDefault = true, Description = "P1 level", Name = "P1" },
			//	new Ticket_Level { Active = true, Id = 2, IsDefault = true, Description = "P2 level", Name = "P2" },
			//	new Ticket_Level { Active = true, Id = 3, IsDefault = true, Description = "P3 level", Name = "P3" });

			builder.Entity<Department>().HasData(
			   new Department { Active = true, Id = 1, IsDefault = true, Description = "Technology ", Name = "Technology" },
			   new Department { Active = true, Id = 2, IsDefault = true, Description = "Hardware", Name = "Hardware" },
			   new Department { Active = true, Id = 3, IsDefault = true, Description = "Software", Name = "Software" });

			builder.Entity<Category>().HasData(
			   new Category { Active = true, Id = 1, IsDefault = true, Description = "Network", Name = "Network" },
			   new Category { Active = true, Id = 2, IsDefault = false, Description = "Printer", Name = "Printer" },
			   new Category { Active = true, Id = 3, IsDefault = false, Description = "Software program", Name = "Software" });

			builder.Entity<Location>().HasData(
				new Location { Active = true, Id = 1, IsDefault = true, Description = "Koramangala", Name = "Koramangala" },
				new Location
				{
					Active = true,
					Id = 2,
					IsDefault = true,
					Description = "Bansawadi",
					Name = "Bansawadi"
				});


			builder.Entity<ApplicationRole>().HasData(
			   new ApplicationRole { Id = 1, NormalizedName = "Admin", RoleName = "Admin", Name = "ADMIN", IsActive = true, IsAgent = false, IsClient = false });
			  // new ApplicationRole { Id = 2, NormalizedName = "Default", RoleName = "Default", Name = "Default", IsActive = true, IsAgent = false, IsClient = false });
			//new ApplicationRole { Id = 3, NormalizedName = "AGENT", RoleName = "AGENT", Name = "AGENT", IsActive = true, IsAgent = true, IsClient = false });

			//builder.Entity<IdentityRoleClaim<Int32>>().HasData(new IdentityRoleClaim<Int32> { Id = 1, RoleId = 1, ClaimType = "FULLACCESS", ClaimValue = "True" });
   //         builder.Entity<IdentityRoleClaim<Int32>>().HasData(new IdentityRoleClaim<Int32> { Id = 2, RoleId = 1, ClaimType = "EDIT", ClaimValue = "True" });
   //         builder.Entity<IdentityRoleClaim<Int32>>().HasData(new IdentityRoleClaim<Int32> { Id = 3, RoleId = 1, ClaimType = "ADD", ClaimValue = "True" });
   //         builder.Entity<IdentityRoleClaim<Int32>>().HasData(new IdentityRoleClaim<Int32> { Id = 4, RoleId = 1, ClaimType = "VIEW", ClaimValue = "True" });

            var hasher = new PasswordHasher<ApplicationUser>();
			var user = new ApplicationUser
			{
				Id = 1,
				Email = "admin@gmail.com",
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = "admin",
				FirstName = "Admin",
				LastName = "Admin",
				EmailConfirmed = false,
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnabled = false,
				AccessFailedCount = 0,
				Active = true,
				NormalizedUserName="admin",
				NormalizedEmail="admin@gmail.com",
				UserType = Infrastructure.Enums.UserTypeEnum.ADMIN,
				PasswordHash = hasher.HashPassword(null, "Abc@123"),
			};
			builder.Entity<ApplicationUser>().HasData(user);

			builder.Entity<IdentityUserRole<Int32>>().HasData(new IdentityUserRole<Int32>() { RoleId = 1, UserId = 1 });
			builder.Entity<IdentityRoleClaim<Int32>>().HasData(new IdentityRoleClaim<Int32>() {Id=1, RoleId = 1,ClaimType= "FULLACCESS",ClaimValue="True" });

		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			string userName=null;
			if (_httpContextAccessor.HttpContext == null)
			{
				return base.SaveChanges();
			}

			if (_httpContextAccessor.HttpContext.User.Identity.Name != null) // During User registration Identity is not set.
			{
				userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
				//ChangeTracker.SetAuditProperties(userName);

			}
			ChangeTracker.SetAuditProperties(userName);

			return await base.SaveChangesAsync();
		}
	}
}
