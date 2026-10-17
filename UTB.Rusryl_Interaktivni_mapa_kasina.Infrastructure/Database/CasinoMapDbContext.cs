using Microsoft.EntityFrameworkCore;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database
{
    public class CasinoMapDbContext : DbContext
    {
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<LocationKind> LocationKinds { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public CasinoMapDbContext(DbContextOptions<CasinoMapDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var 
        }
    }
}
