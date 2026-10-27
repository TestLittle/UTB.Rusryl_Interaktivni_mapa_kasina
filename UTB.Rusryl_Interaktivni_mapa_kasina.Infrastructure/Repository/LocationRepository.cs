using System;
using System.Collections.Generic;
using System.Text;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;
using UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Repository
{
    public class LocationRepository : Repository<Location, int>, ILocationRepository
    {
        public LocationRepository(CasinoMapDbContext context) : base(context) {
        
        }
    }
}
