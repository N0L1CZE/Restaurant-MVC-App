using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UTB.Restaurant.Application.Abstraction;
using UTB.Restaurant.Infrastructure.Identity;

namespace UTB.Restaurant.Application.Implementation
{
    public class SecurityIdentityService : ISecurityService
    {
        UserManager<User> userManager;

        public SecurityIdentityService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public Task<User> FindUserByEmail(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public Task<User> FindUserByUsername(string username)
        {
            return userManager.FindByNameAsync(username);
        }

        public Task<IList<string>> GetUserRoles(User user)
        {
            return userManager.GetRolesAsync(user);
        }

        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
        {
            return userManager.GetUserAsync(principal);
        }
    }
}
