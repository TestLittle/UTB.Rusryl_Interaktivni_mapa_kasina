using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class CardInit
    {
        public IList<Card> GetCards()
        {
            IList<Card> cards = new List<Card>();

            cards.Add(new Card()
            {
                Id = 1,
                CardNumber = 371449635398431,
                ExpirationDate = "03/30",
                SecurityCode = "424",
                CardTypeId = 3
            });

            cards.Add(new Card()
            {
                Id = 2,
                CardNumber = 4012000033330026,
                ExpirationDate = "04/27",
                SecurityCode = "264",
                CardTypeId = 1
            });

            cards.Add(new Card()
            {
                Id = 3,
                CardNumber = 2223000048400011,
                ExpirationDate = "10/28",
                SecurityCode = "655",
                CardTypeId = 2
            });

            return cards;
        }
    }
}