using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Location))]
    public class Location : Entity<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageSrc { get; set; }
        public string Address { get; set; }
        public string CoordsOnMap { get; set; }

        [ForeignKey(nameof(LocationType))]
        public int LocationTypeID { get; set; }
        public LocationType LocationType { get; set; }

        [ForeignKey(nameof(LocationKind))]
        public int LocationKindID { get; set; }
        public LocationKind LocationKind { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
