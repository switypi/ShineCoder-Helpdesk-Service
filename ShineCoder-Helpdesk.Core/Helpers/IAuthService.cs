using Newtonsoft.Json.Linq;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Helpers
{
    public interface IAuthService
    {
        Task<(int, HelpDeskError)> Login(LoginModel model);
        Task<(int, HelpDeskError)> Registeration(RegistrationModel model, string role);
        Task<(int, HelpDeskError)> CreateRole(string roleName);
	}
}