using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;
using UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Repository
{
    public class LocationKindRepository : Repository<Location, int>, ILocationKindRepository
    {
        public LocationKindRepository(CasinoMapDbContext context) : base(context) {
        
        }
    }
}
