using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class CardTypeInit
    {
        public IList<CardType> GetCardTypes()
        {
            IList<CardType> cardTypes = new List<CardType>();

            cardTypes.Add(new CardType()
            {
                Id = 1,
                CardTypeName = "Visa"
            });

            cardTypes.Add(new CardType()
            {
                Id = 2,
                CardTypeName = "Mastercard"
            });

            cardTypes.Add(new CardType()
            {
                Id = 3,
                CardTypeName = "American Express"
            });

            return cardTypes;
        }
    }
}