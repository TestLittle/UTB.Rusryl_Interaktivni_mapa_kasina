
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
