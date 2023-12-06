using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Helpers
{
    public interface IAuthService
    {
        Task<(int, HelpDeskResults)> Login(LoginModel model);
        Task<(int, HelpDeskResults)> Registeration(RegistrationModel model, string role);
        Task<(int, HelpDeskResults)> CreateRole(string roleName);
        Task<(int, HelpDeskResults)> GetAllUsers();
        Task<(int, HelpDeskResults)> GetAllRoles();
        Task<(int, HelpDeskResults)> GetUserRoles(string email);
	}
}