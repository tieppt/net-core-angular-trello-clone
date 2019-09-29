using System.Threading.Tasks;
using Trollo.Common.Contracts.Responses;
using Trollo.Common.Domain;

namespace Trollo.Identity.Services.Contracts
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthSuccessResponse> Register(string email, string password);
    }
}