
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    public class UserLocation
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public IUser<int> User { get; set; }

    }
}
