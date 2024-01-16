using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core
{
	public class StartupDbInitializer
	{
		private const string AdminEmail = "admin@admin.com";
		private const string AdminPassword = "StrongPasswordAdmin123!";

		private static readonly List<ApplicationRole> Roles = new List<ApplicationRole>()
		{
			new ApplicationRole { Id = 1, RoleName = "Admin", Name = "admin", IsActive = true, IsAgent = false, IsClient = false },
			new ApplicationRole { Id = 2, RoleName = "Client", Name = "Client", IsActive = true, IsAgent = false, IsClient = true },
			new ApplicationRole { Id = 3, RoleName = "Agent", Name = "Agent", IsActive = true, IsAgent = true, IsClient = false }
		};

		public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
		{
			//dbContext.Database.EnsureCreated();
			AddRoles(roleManager);
			AddUser(userManager, roleManager);

		}

		private static void AddRoles(RoleManager<ApplicationRole> roleManager)
		{
			if (!roleManager.Roles.Any())
			{
				foreach (var role in Roles)
				{
					_ = roleManager.CreateAsync(role).Result;

				}
			}
		}

		private static void AddUser(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
		{
			if (!userManager.Users.Any())
			{
				var user = new ApplicationUser
				{
					Email = AdminEmail,
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = "admin",
					FirstName = "Admin",
					LastName = "Admin",
					EmailConfirmed = false,
					PhoneNumberConfirmed = false,
					TwoFactorEnabled = false,
					LockoutEnabled = false,
					AccessFailedCount = 0,
					UserType = Infrastructure.Enums.UserTypeEnum.CLIENT
				};
				_ = userManager.CreateAsync(user, AdminPassword).Result;

				var User = userManager.Users.Single(r => r.Email == AdminEmail);
				var Role = roleManager.Roles.Single(r => r.Name == "Admin").RoleName;

				_ = userManager.AddToRoleAsync(User, Role).Result;
			}
		}

		private static  void AddUserRoles(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
		{


			var User = userManager.Users.Single(r => r.Email == AdminEmail);
			var Role = roleManager.Roles.Single(r => r.Name == "Admin").RoleName;

			_ = userManager.AddToRoleAsync(User, Role).Result;
		}
	}
}


