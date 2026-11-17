using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Implementation
{
    public class LocationKindAppService : ILocationKindAppService
    {
        ILocationKindRepository _locationKindRepository;

        public LocationKindAppService(ILocationKindRepository locationKindRepository)
        {
            _locationKindRepository = locationKindRepository;
        }

        public IList<LocationKind> SelectAll()
        {
            return _locationKindRepository.GetAll().ToList();
        }

        public void Create(LocationKind locationKind)
        {
            _locationKindRepository.Add(locationKind);
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            LocationKind? locationKind = _locationKindRepository.GetById(id);
            if (locationKind != null) {
                _locationKindRepository.Delete(locationKind);
                deleted = true;
            }

            return deleted;
        }
    }
}
