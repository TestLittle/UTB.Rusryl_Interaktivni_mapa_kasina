using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    [Table(nameof(Game))]
    public class Game : Entity<int>
    {
        public string GameName { get; set; }
    }
}
