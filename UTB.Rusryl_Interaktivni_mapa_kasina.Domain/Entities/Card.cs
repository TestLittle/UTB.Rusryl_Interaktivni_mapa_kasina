using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Card))]
    public class Card : Entity<int>
    {
        [Required]
        public int CardNumber { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public string SecurityCode { get; set; }
        [ForeignKey(nameof(CardType))]
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
    }
}
