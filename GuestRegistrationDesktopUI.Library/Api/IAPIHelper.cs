using GuestRegistrationDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Api
{
    public interface IAPIconnector
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        
        Task GetLoggedInUserInfo(string token);
    }
}