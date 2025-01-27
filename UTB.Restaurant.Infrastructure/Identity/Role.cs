using Microsoft.AspNetCore.Identity;

namespace UTB.Restaurant.Infrastructure.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role(string role) : base(role)
        {
        }

        public Role() : base()
        {
        }
    }
}
