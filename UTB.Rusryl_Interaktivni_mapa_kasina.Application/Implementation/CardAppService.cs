using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Implementation
{
    public class CardAppService
    {
        ICardRepository _cardRepository;
        public CardAppService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public IList<Card> SelectAll()
        {
            return _cardRepository.GetAll().ToList();
        }
    }
}
