using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(CardType))]
    public class CardType : Entity<int>
    {
        public string CardTypeName { get; set; }
    }
}
