using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Type))]
    public class Type : Entity<int>
    {
        public string TypeName { get; set; }
        public IList<Location> Locations { get; set; }
    }
}
