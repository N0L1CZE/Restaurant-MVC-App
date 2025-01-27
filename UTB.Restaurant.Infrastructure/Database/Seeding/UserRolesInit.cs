using Microsoft.AspNetCore.Identity;

namespace UTB.Restaurant.Infrastructure.Database.Seeding
{
    internal class UserRolesInit
    {
        public List<IdentityUserRole<int>> GetRolesForAdmin()
        {
            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return adminUserRoles;
        }


        public List<IdentityUserRole<int>> GetRolesForManager()
        {
            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return managerUserRoles;
        }
        public List<IdentityUserRole<int>> GetRolesForCustomer()
        {
            List<IdentityUserRole<int>> customerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 3,
                    RoleId = 3
                },
            };

            return customerUserRoles;
        }
    }
}

