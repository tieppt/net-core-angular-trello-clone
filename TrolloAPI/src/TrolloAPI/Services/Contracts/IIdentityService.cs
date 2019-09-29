using System.Threading.Tasks;
using TrolloAPI.Domain;

namespace TrolloAPI.Services.Contracts
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}