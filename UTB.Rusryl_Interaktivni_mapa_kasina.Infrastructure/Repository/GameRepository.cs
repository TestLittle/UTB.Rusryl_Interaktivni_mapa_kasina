using System;
using System.Collections.Generic;
using System.Text;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;
using UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Repository
{
    public class GameRepository : Repository<Game, int>, IGameRepository
    {
        public GameRepository(CasinoMapDbContext context) : base(context) {
        
        }
    }
}
