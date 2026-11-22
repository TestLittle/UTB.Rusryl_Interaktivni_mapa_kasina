using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Validations;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Location))]
    public class Location : Entity<int>
    {
        [Required]
        [StringLength(100)]
        [FirstLetterUppercase]
        public string Name { get; set; }
        [Required]
        public string ImageSrc { get; set; }
        [Required]
        [FirstLetterUppercase]
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        [ForeignKey(nameof(LocationType))]
        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }

        [ForeignKey(nameof(LocationKind))]
        public int LocationKindId { get; set; }
        public LocationKind LocationKind { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
