using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Implementation
{
    public class GameAppService : IGameAppService
    {
        IGameRepository _gameRepository;
        public GameAppService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IList<Game> SelectAll()
        {
            return _gameRepository.GetAll().ToList();
        }
    }
}
