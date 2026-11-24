using Microsoft.AspNetCore.Identity;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class UserRoleInit
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
                }
            };

            return adminUserRoles;
        }
    }
}
