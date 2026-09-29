using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
