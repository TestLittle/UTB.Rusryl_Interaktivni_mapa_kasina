using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(LocationType))]
    public class LocationType : Entity<int>
    {
        public string LocationTypeName { get; set; }
        public IList<Location> Locations { get; set; }
    }
}
