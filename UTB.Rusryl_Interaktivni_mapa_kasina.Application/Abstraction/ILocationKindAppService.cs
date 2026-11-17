using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction
{
    public interface ILocationKindAppService
    {
        IList<LocationKind> SelectAll();
        void Create(LocationKind locationKind);
        bool Delete(int id);
    }
}
