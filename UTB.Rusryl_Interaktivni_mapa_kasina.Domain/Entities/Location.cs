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

        [ForeignKey(nameof(Type))]
        public int TypeID { get; set; }

        [ForeignKey(nameof(Kind))]
        public int KindID { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
