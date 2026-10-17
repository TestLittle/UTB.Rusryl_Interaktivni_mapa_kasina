using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(LocationKind))]
    public class LocationKind : Entity<int>
    {
        public string LocationKindName { get; set; }
        public IList<Location> Locations { get; set; }
    }
}
