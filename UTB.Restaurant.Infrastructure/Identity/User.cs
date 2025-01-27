using Microsoft.AspNetCore.Identity;
using UTB.Restaurant.Domain.Entities.Interfaces;

namespace UTB.Restaurant.Infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}

