using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    public class Entity<TKey> : IEntity<TKey> where TKey : notnull
    {
        public TKey Id { get; set; }
    }
}
