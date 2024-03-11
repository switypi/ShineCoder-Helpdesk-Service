using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core.Enums;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Helpers
{
    public interface IAuthService
    {
        Task<(int, HelpDeskResults)> Login(LoginModel model);
        Task<(int, HelpDeskResults)> RegisterationAsync(UserModel model);
        Task<(int, HelpDeskResults)> CreateRole(RoleModel roleName);
        Task<(int, HelpDeskResults)> GetAllUsers();
        Task<IEnumerable<ApplicationUser>> GetAllUsers(Expression<Func<ApplicationUser, bool>> filter = null, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null);
        Task<List<ApplicationRole>> GetAllRoles();
        Task<(int, HelpDeskResults)> GetRolesById(int id);
        Task<(int, HelpDeskResults)> GetUserRoles(string email);
		 Task<(int, HelpDeskResults)> UpdateUser(UserModel userModel);
        Task<bool> IsRoleExists(string rolename);
        Task<bool> DeleteRole(int id);
        Task<(int, HelpDeskResults)> UpdateRole(ApplicationRole role);
        Task<(int, HelpDeskResults)> UpdateRoleClaim(ApplicationRole role,ApplicationUser user, Dictionary<string, string> claims);
        Task<(int, HelpDeskResults)> UpdateUserClaim( ApplicationUser user, Dictionary<string, string> claims);
        Task<(int, HelpDeskResults)> GetUserRoleClaims(ApplicationUser user,UserTypeEnum userType,string roleName,int roleId);
       // Task<(int, HelpDeskResults)> GetUserClaims(ApplicationUser user, UserTypeEnum userType, string roleName, int roleId);
       Task<bool> ResetPasswordFromAdmin(UserModel user);
        Task<(int, HelpDeskResults)> ForgotPassword(ForgotPasswordModel forgotPassword);
        Task<(int, HelpDeskResults)> ResetPassword(ResetPasswordModel resetPassword);
    }
}