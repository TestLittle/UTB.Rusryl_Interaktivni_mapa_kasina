namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
