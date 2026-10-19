using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class GameInit
    {
        public IList<Game> GetGames()
        {
            IList<Game> games = new List<Game>();

            games.Add(new Game()
            {
                Id = 1,
                GameName = "poker"
            });

            return games;
        }
    }
}