using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database
{
    public class CasinoMapDbContext : DbContext
    {
        public CasinoMapDbContext(DbContextOptions<CasinoMapDbContext> options) : base(options)
        {

        }
    }
}
