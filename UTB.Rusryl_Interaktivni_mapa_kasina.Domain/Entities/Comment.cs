
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Comment))]
    public class Comment : Entity<int>
    {
        [Required]
        [StringLength(255)]
        public string Content { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAndTime { get; protected set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public IUser<int> User { get; set; }
        
    }
}
