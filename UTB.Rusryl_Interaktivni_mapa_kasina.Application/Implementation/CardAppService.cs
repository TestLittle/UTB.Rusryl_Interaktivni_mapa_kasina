using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Implementation
{
    public class CardAppService : ICardAppService
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

        public void Create(Card card)
        {
            _cardRepository.Add(card);
        }

        public void Edit(int id)
        {
            Card? card = _cardRepository.GetById(id);

            if (card != null)
            {
                _cardRepository.Edit(card);
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            Card? card = _cardRepository.GetById(id);
            if (card != null) {
                _cardRepository.Delete(card);
                deleted = true;
            }

            return deleted;
        }
    }
}
