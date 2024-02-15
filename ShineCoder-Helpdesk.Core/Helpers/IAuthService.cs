using System.Linq.Expressions;
using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Helpers
{
    public interface IAuthService
    {
        Task<(int, HelpDeskResults)> Login(LoginModel model);
        Task<(int, HelpDeskResults)> RegisterationAsync(UserModel model, string role);
        Task<(int, HelpDeskResults)> CreateRole(string roleName);
        Task<(int, HelpDeskResults)> GetAllUsers();
        Task<IEnumerable<ApplicationUser>> GetAllUsers(Expression<Func<ApplicationUser, bool>> filter = null, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null);
        Task<(int, HelpDeskResults)> GetAllRoles();
        Task<(int, HelpDeskResults)> GetUserRoles(string email);
		 Task<(int, HelpDeskResults)> UpdateUser(UserModel userModel);
	}
}