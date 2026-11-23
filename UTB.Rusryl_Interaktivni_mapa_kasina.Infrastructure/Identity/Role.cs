using Microsoft.AspNetCore.Identity;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Identity
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
