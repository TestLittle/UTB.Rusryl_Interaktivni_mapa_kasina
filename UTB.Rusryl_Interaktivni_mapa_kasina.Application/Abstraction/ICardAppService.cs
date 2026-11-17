using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction
{
    public interface ICardAppService
    {
        IList<Card> SelectAll();
        void Create(Card card);
        void Edit(int id);
        bool Delete(int id);
    }
}
