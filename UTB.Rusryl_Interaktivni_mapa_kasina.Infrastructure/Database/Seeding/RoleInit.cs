using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Enums;
using UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Identity;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class RoleInit
    {
        public List<Role> GetRolesAMC()
        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = Roles.Admin.ToString(),
                NormalizedName = Roles.Admin.ToString().ToUpper(),
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleLoggedUser = new Role()
            {
                Id = 2,
                Name = Roles.LoggedUser.ToString(),
                NormalizedName = Roles.LoggedUser.ToString().ToUpper(),
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };

            roles.Add(roleAdmin);
            roles.Add(roleLoggedUser);

            return roles;
        }
    }
}
