using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Helpers
{
    public interface IAuthService
    {
        Task<(int, string)> Login(LoginModel model);
        Task<(int, string)> Registeration(RegistrationModel model, string role);
    }
}