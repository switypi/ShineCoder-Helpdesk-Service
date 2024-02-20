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
        public async Task<(int, HelpDeskResults)> RegisterationAsync(UserModel model)
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
                    UserType = (Infrastructure.Enums.UserTypeEnum)model.UserType,
                    DepartmentId = model.DepartmentId,
                    ImageBytes = model.ImageBytes,
                    PhoneNumber = model.PhoneNumber,
                    JobTitle = model.JobTitle,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Active = false

                };
                //ApplicationRole rolee = new ApplicationRole();
                //rolee.IsActive = false;
                //rolee.IsClient = false;
                //rolee.IsAgent = false;
                //rolee.Name = role;
                //rolee.RoleName = role;

                var createUserResult = await userManager.CreateAsync(user, model.Password);
                if (!createUserResult.Succeeded)
                    return (0, new HelpDeskResults { Succeeded = createUserResult.Succeeded, Message = "", Errors = createUserResult.Errors });
                //var role = await roleManager.FindByNameAsync("Default");
                //if (await roleManager.FindByNameAsync(role) == null)
                //    await roleManager.CreateAsync(rolee);

                //if (await roleManager.RoleExistsAsync(role))
               

                //await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), "False"));
                //await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.EDIT), "False"));
                //await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.ADD), "False"));
                //await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.VIEW), "False"));
                //await userManager.AddClaimAsync(user, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.DELETE), "False"));

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
            if (user != null && user.Active == false)
                return (0, new HelpDeskResults { Succeeded = false, Message = "Un-Athorized login.Please contact support." });
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

        public async Task<(int, HelpDeskResults)> CreateRole(RoleModel role)
        {
            var roleExist = await roleManager.RoleExistsAsync(role.Name);
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 1
                ApplicationRole rolee = new ApplicationRole();
                rolee.IsActive = role.IsActive;
                rolee.IsClient = role.IsClient;
                rolee.IsAgent = role.IsAgent;
                rolee.Name = role.Name;
                rolee.RoleName = role.Name;
                rolee.NormalizedName = role.Name;
                var roleResult = await roleManager.CreateAsync(rolee);

                if (roleResult.Succeeded)
                {
                    //await roleManager.AddClaimAsync(rolee, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), "False"));
                    //await roleManager.AddClaimAsync(rolee, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.EDIT), "False"));
                    //await roleManager.AddClaimAsync(rolee, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.ADD), "False"));
                    //await roleManager.AddClaimAsync(rolee, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.VIEW), "False"));
                    //await roleManager.AddClaimAsync(rolee, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.DELETE), "False"));

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

        public async Task<(int, HelpDeskResults)> UpdateUserClaim(IEnumerable<ApplicationRole> roles,ApplicationUser user, Dictionary<string, string> claims)
        {
            try
            {
                List<Claim> clms = new List<Claim>();
                bool isSuccess = true;
                IEnumerable<IdentityError> errors=null;


                var roleAssigned = await userManager.GetRolesAsync(user);
                var issRoleremoved = await userManager.RemoveFromRolesAsync(user, roleAssigned);

                if(!issRoleremoved.Succeeded)
                    return (0, new HelpDeskResults { Succeeded = false, Message = "Server error occured." });

                var IsrolesAdded=await userManager.AddToRolesAsync(user,roles.Select(x=>x.Name));

                if (!IsrolesAdded.Succeeded)
                    return (0, new HelpDeskResults { Succeeded = false, Message = "Server error occured." });
                foreach (var role in roles)
                {
                    var existingclaimsforUser = await roleManager.GetClaimsAsync(role);
                    foreach (var claim in existingclaimsforUser)
                    {
                        var result = await roleManager.RemoveClaimAsync(role, claim);
                        if (!result.Succeeded)
                        {
                            isSuccess = false;
                            errors = result.Errors;
                        }

                    }

                    foreach (var clm in claims)
                    {
                        clms.Add(new Claim(clm.Key, clm.Value));
                        if (isSuccess)
                        {
                            var res = await roleManager.AddClaimAsync(role, new Claim(clm.Key, clm.Value));
                            if (res.Succeeded)
                            {
                                _logger.LogInformation(1, "Claims updated");
                                return (1, new HelpDeskResults { Succeeded = true, Message = "Claims  updated successfully!" });
                            }
                            else
                            {
                                _logger.LogInformation(2, "Error");
                                return (0, new HelpDeskResults { Succeeded = false, Errors = res.Errors });
                            }
                        }
                        else
                        {
                            _logger.LogInformation(2, "Error");
                            return (0, new HelpDeskResults { Succeeded = false, Errors = errors });
                        }
                    }
                }
                return (0, new HelpDeskResults { Succeeded = false, Message = "No claims to update." });
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

        public async Task<List<ApplicationRole>> GetAllRoles()
        {
            try
            {
                var roles = await roleManager.Roles.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in GetAllRoles");
                throw ex;
            }
        }
        public async Task<(int, HelpDeskResults)> GetRolesById(int id)
        {
            try
            {
                var roles = await roleManager.Roles.Where(x => x.Id == id).ToListAsync();
                return (1, new HelpDeskResults { Succeeded = true, Result = roles.ToJArray() });
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in GetAllRoles");
                return (0, new HelpDeskResults { Succeeded = false, Message = ex.Message });
            }

        }


        public async Task<bool> IsRoleExists(string rolename)
        {
            try
            {
                var roles = await roleManager.RoleExistsAsync(rolename);
                return roles != null ? true : false;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in IsRoleExists");
                throw ex;
            }
        }


        public async Task<bool> DeleteRole(int id)
        {
            try
            {
                var role = await roleManager.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                role.IsActive = false;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in IsRoleExists");
                throw ex;
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
                user.Active = userModel.Active;
                var res = await userManager.UpdateAsync(user);
                if (!res.Succeeded)
                    return (0, new HelpDeskResults { Succeeded = res.Succeeded, Message = "", Errors = res.Errors });
            }
            else if (userModel.OperationContext == OperationContextEnum.DELETEUSER)
            {

                var isDeleted = await userManager.DeleteAsync(user);

                if (!isDeleted.Succeeded)
                    return (0, new HelpDeskResults { Succeeded = isDeleted.Succeeded, Message = "", Errors = isDeleted.Errors });

            }
            else if (userModel.OperationContext == OperationContextEnum.UPDATE)
            {
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Email = userModel.Email;
                user.ImageBytes = userModel.ImageBytes;
                //user.Active=userModel.Active;
                user.Address = userModel.Address;
                user.PhoneNumber = userModel.PhoneNumber;
                user.City = userModel.City;
                user.State = userModel.State;
                //user.UserName=userModel.UserName;
                user.NormalizedEmail = userModel.Email;
                user.NormalizedUserName = userModel.UserName;
                user.JobTitle = userModel.JobTitle;
                if (!string.IsNullOrEmpty(userModel.Password))
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, userModel.Password);
                var res = await userManager.UpdateAsync(user);
                if (!res.Succeeded)
                    return (0, new HelpDeskResults { Succeeded = res.Succeeded, Message = "Unable to to update user", Errors = res.Errors });
            }

            return (1, new HelpDeskResults { Succeeded = true, Message = "User updated successfully!" });
        }

		public async Task<(int, HelpDeskResults)> UpdateRolePermissions(UserRolePermissionModel model)
		{

            foreach (var item in model.RoleNames)
            {
				var roleModel = roleManager.Roles.Where(x => x.Name == item).FirstOrDefault();
				var usersInRole =await  userManager.GetUsersInRoleAsync(item).ContinueWith(x=>x.Result.Where(v=>v.Id==model.UserId));
				if(usersInRole != null)
				{
					var userRoleClaims =await roleManager.GetClaimsAsync(roleModel);

					foreach(var userClaim in userRoleClaims)
					{
						switch (userClaim.Type)
						{
							case nameof(ClaimEnum.FULLACCESS):
								if(model.IsFullAccess!=null && model.IsFullAccess!=bool.Parse(userClaim.Value))
								{
									await roleManager.RemoveClaimAsync(roleModel, userClaim);
									await roleManager.AddClaimAsync(roleModel, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), model.IsFullAccess.ToString()));
								}

								break;
							case nameof(ClaimEnum.VIEW):
								if (model.IsFullAccess != null && model.IsFullAccess != bool.Parse(userClaim.Value))
								{
									await roleManager.RemoveClaimAsync(roleModel, userClaim);
									await roleManager.AddClaimAsync(roleModel, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), model.IsFullAccess.ToString()));
								}

								break;
							case nameof(ClaimEnum.ADD):
								if (model.IsFullAccess != null && model.IsFullAccess != bool.Parse(userClaim.Value))
								{
									await roleManager.RemoveClaimAsync(roleModel, userClaim);
									await roleManager.AddClaimAsync(roleModel, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), model.IsFullAccess.ToString())); ;
								}

								break;
							case nameof(ClaimEnum.EDIT):
								if (model.IsFullAccess != null && model.IsFullAccess != bool.Parse(userClaim.Value))
								{
									await roleManager.RemoveClaimAsync(roleModel, userClaim);
									await roleManager.AddClaimAsync(roleModel, new Claim(Enum.GetName(typeof(ClaimEnum), ClaimEnum.FULLACCESS), model.IsFullAccess.ToString())); ;
								}

								break;

						}
					}

					

				}
			


			}

			return (1, new HelpDeskResults { Succeeded = true, Message = "User updated successfully!" });

		}


        public async Task<(int, HelpDeskResults)> GetUserRoleClaims(ApplicationUser user)
        {

            List<UserRoleClaimModel> returnObjList = new List<UserRoleClaimModel>();
            var roles = await userManager.GetRolesAsync(user);
            
            if(roles!=null)
            {
                foreach (var role in roles)
                {
                    var roleObject = await roleManager.Roles.Where(x => x.Name == role).FirstOrDefaultAsync();
                    var claims=await roleManager.GetClaimsAsync(roleObject);
                    UserRoleClaimModel obj = new UserRoleClaimModel();
                    obj.RoleId = roleObject.Id;
					foreach (var cl in claims)
                    {
                       switch (cl.Type)
                        {
                            case nameof(ClaimEnum.FULLACCESS):
                                obj.IsFullAccess =bool.Parse(cl.Value);
                                break;
                            case nameof(ClaimEnum.VIEW):
								obj.IsViewAccess = bool.Parse(cl.Value);
								break;
                            case nameof(ClaimEnum.ADD):
								obj.IsAddAccess = bool.Parse(cl.Value);
								break;
                            case nameof(ClaimEnum.EDIT):
								obj.IsEditAccess = bool.Parse(cl.Value);
								break;
                        }
                        returnObjList.Add(obj);
                    }

                }
                
            }
            return (1, new HelpDeskResults { Succeeded = true, Result= returnObjList.ToJArray() });
        }

    }
}
