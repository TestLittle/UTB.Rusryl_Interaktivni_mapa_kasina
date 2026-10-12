using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Kind))]
    public class Kind : Entity<int>
    {
        public string KindName { get; set; }
    }
}
