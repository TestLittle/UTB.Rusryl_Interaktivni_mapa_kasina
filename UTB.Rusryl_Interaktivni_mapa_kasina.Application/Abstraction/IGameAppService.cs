using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction
{
    public interface IGameAppService
    {
        IList<Game> SelectAll();
    }
}
