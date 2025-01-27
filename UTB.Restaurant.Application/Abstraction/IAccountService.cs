using UTB.Restaurant.Application.ViewModels;
using UTB.Restaurant.Infrastructure.Identity.Enums;

namespace UTB.Restaurant.Application.Abstraction
{
    public interface IAccountService
    {
        Task<bool> Login(LoginViewModel vm);
        Task Logout();

        Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);
    }
}

