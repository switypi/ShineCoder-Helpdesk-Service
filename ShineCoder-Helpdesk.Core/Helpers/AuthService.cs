using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ShineCoder_Helpdesk.Core.Enums;
using ShineCoder_Helpdesk.Infrastructure.Enums;
using ShineCoder_Helpdesk.Infrastructure.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShineCoder_Helpdesk.Core.Helpers
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<ApplicationRole> roleManager;
		private readonly IConfiguration _configuration;
		private readonly ILogger _logger;
		public AuthService(ILogger<AuthService> logger, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			_configuration = configuration;
			_logger=logger;

		}
		public async Task<(int, string)> Registeration(RegistrationModel model, string role)
		{
			var userExists = await userManager.FindByNameAsync(model.Username);
			if (userExists != null)
				return (0, "User already exists");

			ApplicationUser user = new()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Username,
				FirstName = model.FirstName,
				LastName = model.LastName,
				EmailConfirmed = false,
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnabled = false,
				AccessFailedCount = 0,
				UserType = Infrastructure.Enums.UserTypeEnum.CLIENT

			};
			ApplicationRole rolee = new ApplicationRole();
			rolee.IsActive = false;
			rolee.IsClient = false;
			rolee.IsAgent = false;
			rolee.Name = role;

			var createUserResult = await userManager.CreateAsync(user, model.Password);
			if (!createUserResult.Succeeded)
				return (0, "User creation failed! Please check user details and try again.");

			if (!await roleManager.RoleExistsAsync(role))
				await roleManager.CreateAsync(rolee);

			if (await roleManager.RoleExistsAsync(role))
				await userManager.AddToRoleAsync(user, role);

			await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), "False"));
			await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.EDIT), "False"));
			await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.ADD), "False"));
			await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.VIEW), "False"));
			await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.DELETE), "False"));

			return (1, "User created successfully!");
		}

		public async Task<(int, string)> Login(LoginModel model)
		{
			var user = await userManager.FindByNameAsync(model.Username);
			if (user == null)
				return (0, "Invalid username");
			if (!await userManager.CheckPasswordAsync(user, model.Password))
				return (0, "Invalid password");

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
			return (1, token);
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
				Expires = DateTime.UtcNow.AddMinutes(1),
				SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
				Subject = new ClaimsIdentity(claims)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public async Task<(int, string)> CreateRole(string roleName)
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
				var roleResult = await roleManager.CreateAsync(rolee);

				if (roleResult.Succeeded)
				{
					_logger.LogInformation(1, "Roles Added");
					return (1, "Role created successfully!");
				}
				else
				{
					_logger.LogInformation(2, "Error");
					return (1, roleResult.Errors.ToString());
				}
			}
			else
			{
				_logger.LogInformation(2, "Role Exist");
				return (0, "Role Exist");

			}
		}

		public async Task<(int, string)> UpdateRole(ApplicationRole role)
		{
			var roleResult = await roleManager.UpdateAsync(role);

			if (roleResult.Succeeded)
			{
				_logger.LogInformation(1, "Roles updated");
				return (1, "role updated successfully!");
			}
			else
			{
				_logger.LogInformation(2, "Error");
				return (0, roleResult.Errors.ToString());
			}

		}

		public async Task<(int, string)> UpdateUserClaim(ApplicationUser user, Dictionary<string, string> claims)
		{
			List<Claim> clms = new List<Claim>();
			var existingclaimsforUser=await userManager.GetClaimsAsync(user);

			foreach (var clm in claims)
			{
				clms.Add(new Claim(clm.Key,clm.Value));
			}
			
			var result = await userManager.RemoveClaimsAsync(user, existingclaimsforUser);

			if (result.Succeeded)
			{
				var res=await userManager.AddClaimsAsync(user, clms);
				if (res.Succeeded)
				{
					_logger.LogInformation(1, "Claims updated");
					return (1, "Claims  updated successfully!");
				}
				else
				{
					_logger.LogInformation(2, "Error");
					return (0, result.Errors.ToString());
				}
			}
			else
			{
				_logger.LogInformation(2, "Error");
				return (0, result.Errors.ToString());
			}
		}
	}
}
