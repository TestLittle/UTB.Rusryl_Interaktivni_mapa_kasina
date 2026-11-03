using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Implementation
{
    public class LocationAppService : ILocationAppService
    {
        ILocationRepository _locationRepository;

        public LocationAppService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IList<Location> SelectAll()
        {
            return _locationRepository.GetAll().ToList();
        }

    }
}
