using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Trollo.Common.Contracts.Responses;
using Trollo.Common.Exceptions;
using Trollo.Identity.Helpers;
using Trollo.Identity.Identity;
using Trollo.Identity.Services.Contracts;

namespace Trollo.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public IdentityService(
            UserManager<AppUser> userManager,
            RoleManager<UserRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<AuthSuccessResponse> Register(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
                throw new ApiException<AuthFailedResponse>(HttpStatusCode.BadRequest, new AuthFailedResponse
                {
                    Errors = new[] {"User with this email address already exists"}
                });

            var newUserId = Guid.NewGuid();
            var now = DateTime.UtcNow;
            var newUser = new AppUser
            {
                Id = newUserId.ToString(),
                Email = email,
                UserName = email,
                CreatedAt = now,
                ModifiedAt = now
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
                throw new ApiException<AuthFailedResponse>(HttpStatusCode.BadRequest, new AuthFailedResponse
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                });

            var createdUserRole = await _userManager.AddToRoleAsync(newUser, "User");
            if (!createdUserRole.Succeeded)
                throw new ApiException<AuthFailedResponse>(HttpStatusCode.BadRequest, new AuthFailedResponse
                {
                    Errors = createdUserRole.Errors.Select(x => x.Description)
                });

            var result = await JwtHelper.GenerateAuthenticationResultForUserAsync(newUser, _userManager, _roleManager,
                _configuration);
            return new AuthSuccessResponse
            {
                Token = result.Token
            };
        }

        public async Task<AuthSuccessResponse> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) throw new ApiException<string>(HttpStatusCode.NotFound, "User does not exist");

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!userHasValidPassword)
                throw new ApiException<string>(HttpStatusCode.BadRequest, "Email/Password combination is invalid");

            var result = await JwtHelper.GenerateAuthenticationResultForUserAsync(user, _userManager, _roleManager,
                _configuration);
            return new AuthSuccessResponse
            {
                Token = result.Token
            };
        }
    }
}