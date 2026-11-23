using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser<int>
    { 
    }
}
