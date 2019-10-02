using System.Threading.Tasks;
using Trollo.Common.Contracts.Responses;

namespace Trollo.Identity.Services.Contracts
{
    public interface IIdentityService
    {
        Task<AuthSuccessResponse> Register(string email, string password);
        Task<AuthSuccessResponse> Login(string email, string password);
    }
}