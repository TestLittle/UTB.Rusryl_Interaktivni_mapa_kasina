using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Validations;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Card))]
    public class Card : Entity<int>
    {
        [Required]
        [CardNumberLength]
        public string CardNumber { get; set; }
        [Required]
        [CardExpirationDateFormat]
        public string ExpirationDate { get; set; }
        [Required]
        [CardSecurityCodeLength]
        public string SecurityCode { get; set; }
        [ForeignKey(nameof(CardType))]
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
    }
}
