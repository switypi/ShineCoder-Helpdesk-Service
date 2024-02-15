using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core.Enums;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure.Enums;
using ShineCoder_Helpdesk.Infrastructure.Models;


namespace ShineCoder_Helpdesk.Core.Helpers
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<ApplicationRole> roleManager;
		private readonly IConfiguration _configuration;
		
		private readonly ILogger _logger;
		public AuthService(ILogger<AuthService> logger, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, 
			IConfiguration configuration)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			_configuration = configuration;
			_logger = logger;

		}
		public async Task<(int, HelpDeskResults)> RegisterationAsync(UserModel model, string role)
		{
			try
			{
				var userExists = await userManager.FindByNameAsync(model.UserName);
				if (userExists != null)
					return (0, new HelpDeskResults(true, "User exists."));

				ApplicationUser user = new()
				{
					Email = model.Email,
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = model.UserName,
					FirstName = model.FirstName,
					LastName = model.LastName,
					EmailConfirmed = false,
					PhoneNumberConfirmed = false,
					TwoFactorEnabled = false,
					LockoutEnabled = false,
					AccessFailedCount = 0,
					UserType = role == "CLIENT" ? Infrastructure.Enums.UserTypeEnum.CLIENT : Infrastructure.Enums.UserTypeEnum.AGENT,
					DepartmentId = model.DepartmentId,
					ImageBytes = model.ImageBytes,


				};
				ApplicationRole rolee = new ApplicationRole();
				rolee.IsActive = false;
				rolee.IsClient = false;
				rolee.IsAgent = false;
				rolee.Name = role;
				rolee.RoleName = role;

				var createUserResult = await userManager.CreateAsync(user, model.Password);
				if (!createUserResult.Succeeded)
					return (0, new HelpDeskResults { Succeeded = createUserResult.Succeeded, Message = "", Errors = createUserResult.Errors });
				//var d = await roleManager.FindByNameAsync(role);
				if (await roleManager.FindByNameAsync(role) == null)
					await roleManager.CreateAsync(rolee);

				if (await roleManager.RoleExistsAsync(role))
					await userManager.AddToRoleAsync(user, role);

				await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), "False"));
				await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.EDIT), "False"));
				await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.ADD), "False"));
				await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.VIEW), "False"));
				await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.DELETE), "False"));

				return (1, new HelpDeskResults { Succeeded = true, Message = "User created successfully!" });
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async Task<(int, HelpDeskResults)> Login(LoginModel model)
		{
			var user = await userManager.FindByNameAsync(model.Username);
			if (user == null)
				return (0, new HelpDeskResults { Succeeded = false, Message = "Invalid username" });
			if (!await userManager.CheckPasswordAsync(user, model.Password))
				return (0, new HelpDeskResults { Succeeded = false, Message = "Invalid password" });

			var userRoles = await userManager.GetRolesAsync(user);
			var authClaims = new List<Claim>
			{
			   new Claim(ClaimTypes.Name, user.UserName),
			   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};

			foreach (var userRole in userRoles)
			{
				authClaims.Add(new Claim(ClaimTypes.Role, userRole));
			}
			string token = GenerateToken(authClaims);
			return (1, new HelpDeskResults { Succeeded = true, Message = token });
		}
		private string GenerateToken(IEnumerable<Claim> claims)
		{
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
			var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWT:Expiry"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = _configuration["JWT:ValidIssuer"],
				Audience = _configuration["JWT:ValidAudience"],

				//Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
				Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
				SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
				Subject = new ClaimsIdentity(claims)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public async Task<(int, HelpDeskResults)> CreateRole(string roleName)
		{
			var roleExist = await roleManager.RoleExistsAsync(roleName);
			if (!roleExist)
			{
				//create the roles and seed them to the database: Question 1
				ApplicationRole rolee = new ApplicationRole();
				rolee.IsActive = false;
				rolee.IsClient = false;
				rolee.IsAgent = false;
				rolee.Name = roleName;
				rolee.RoleName = roleName;
				var roleResult = await roleManager.CreateAsync(rolee);

				if (roleResult.Succeeded)
				{
					_logger.LogInformation(1, "Roles Added");
					return (1, new HelpDeskResults { Succeeded = true, Message = "Role created successfully!" });
				}
				else
				{
					_logger.LogInformation(2, "Error");
					return (1, new HelpDeskResults { Succeeded = false, Errors = roleResult.Errors });
				}
			}
			else
			{
				_logger.LogInformation(2, "Role Exist");
				return (0, new HelpDeskResults { Succeeded = true, Message = "Role Exist" });

			}
		}

		public async Task<(int, HelpDeskResults)> UpdateRole(ApplicationRole role)
		{
			var roleResult = await roleManager.UpdateAsync(role);

			if (roleResult.Succeeded)
			{
				_logger.LogInformation(1, "Roles updated");
				return (1, new HelpDeskResults { Succeeded = true, Message = "role updated successfully!" });
			}
			else
			{
				_logger.LogInformation(2, "Error");
				return (0, new HelpDeskResults { Succeeded = false, Errors = roleResult.Errors });
			}

		}

		public async Task<(int, HelpDeskResults)> UpdateUserClaim(ApplicationUser user, Dictionary<string, string> claims)
		{
			try
			{
				List<Claim> clms = new List<Claim>();
				var existingclaimsforUser = await userManager.GetClaimsAsync(user);

				foreach (var clm in claims)
				{
					clms.Add(new Claim(clm.Key, clm.Value));
				}

				var result = await userManager.RemoveClaimsAsync(user, existingclaimsforUser);

				if (result.Succeeded)
				{
					var res = await userManager.AddClaimsAsync(user, clms);
					if (res.Succeeded)
					{
						_logger.LogInformation(1, "Claims updated");
						return (1, new HelpDeskResults { Succeeded = true, Message = "Claims  updated successfully!" });
					}
					else
					{
						_logger.LogInformation(2, "Error");
						return (0, new HelpDeskResults { Succeeded = false, Errors = result.Errors });
					}
				}
				else
				{
					_logger.LogInformation(2, "Error");
					return (0, new HelpDeskResults { Succeeded = false, Errors = result.Errors });
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("Error in UpdateClaim.");
				throw ex;
			}

		}

		public async Task<(int, HelpDeskResults)> GetUserRoles(string email)
		{
			try
			{
				// Resolve the user via their email
				var user = await userManager.FindByEmailAsync(email);
				// Get the roles for the user
				var roles = await userManager.GetRolesAsync(user);
				return (1, new HelpDeskResults { Succeeded = true, Result = roles.ToJArray() });
			}
			catch (Exception ex)
			{
				_logger.LogError("Error in GetUserRoles");
				throw ex;
			}

		}

		public async Task<(int, HelpDeskResults)> GetAllUsers()
		{
			try
			{
				var users = await userManager.Users.ToListAsync();
				return (1, new HelpDeskResults { Succeeded = true, Result = users.ToJArray() });
			}
			catch (Exception ex)
			{

				_logger.LogError("Error in GetAllUsers");
				return (0, new HelpDeskResults { Succeeded = false, Message = ex.Message });
			}
		}

		public async Task<IEnumerable<ApplicationUser>> GetAllUsers(Expression<Func<ApplicationUser, bool>> filter = null, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null)
		{
			IQueryable<ApplicationUser> query = userManager.Users;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			//foreach (var includeProperty in includeProperties.Split
			//    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			//{
			//    query = query.Include(includeProperty);
			//}

			if (orderBy != null)
			{
				return await orderBy(query).ToListAsync();
			}
			else
			{
				return await query.ToListAsync();
			}
		}

		public async Task<(int, HelpDeskResults)> GetAllRoles()
		{
			try
			{
				var roles = await roleManager.Roles.ToListAsync();
				return (1, new HelpDeskResults { Succeeded = true, Result = roles.ToJArray() });
			}
			catch (Exception ex)
			{

				_logger.LogError("Error in GetAllRoles");
				return (0, new HelpDeskResults { Succeeded = false, Message = ex.Message });
			}
		}

		public async Task<(int, HelpDeskResults)> UpdateUser(UserModel userModel)
		{
			var user = await userManager.FindByIdAsync(userModel.Id.ToString());

			if (userModel.OperationContext == OperationContextEnum.RESETPASSWORD)
			{
				user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Abc@123");
				var res = await userManager.UpdateAsync(user);
				if (!res.Succeeded)
					return (0, new HelpDeskResults { Succeeded = res.Succeeded, Message = "", Errors = res.Errors });
			}
			else if (userModel.OperationContext == OperationContextEnum.ACTIVATEDEACTIVATEUSER)
			{
				user.Active =  userModel.Active;
				var res=await userManager.UpdateAsync(user);
				if (!res.Succeeded)
					return (0, new HelpDeskResults { Succeeded = res.Succeeded, Message = "", Errors = res.Errors });
			}
			else if (userModel.OperationContext == OperationContextEnum.DELETEUSER)
			{
				
				var isDeleted = await userManager.DeleteAsync(user);

				if (!isDeleted.Succeeded)
					return (0, new HelpDeskResults { Succeeded = isDeleted.Succeeded, Message = "", Errors = isDeleted.Errors });

			}

			return (1, new HelpDeskResults { Succeeded = true, Message = "User updated successfully!" });
		}

	}
}
