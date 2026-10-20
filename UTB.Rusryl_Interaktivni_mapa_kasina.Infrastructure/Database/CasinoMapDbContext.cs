using Microsoft.EntityFrameworkCore;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding;

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

            LocationTypeInit locationTypeInit = new LocationTypeInit();
            modelBuilder.Entity<LocationType>().HasData(locationTypeInit.GetLocationTypes());

            LocationKindInit locationKindInit = new LocationKindInit();
            modelBuilder.Entity<LocationKind>().HasData(locationKindInit.GetLocationKinds());
            
            LocationInit locationInit = new LocationInit();
            modelBuilder.Entity<Location>().HasData(locationInit.GetLocations());

            GameInit gameInit = new GameInit();
            modelBuilder.Entity<Game>().HasData(gameInit.GetGames());

            CardTypeInit cardTypeInit = new CardTypeInit();
            modelBuilder.Entity<CardType>().HasData(cardTypeInit.GetCardTypes());

            CardInit cardInit = new CardInit();
            modelBuilder.Entity<Card>().HasData(cardInit.GetCards());

            CommentInit commentInit = new CommentInit();
            modelBuilder.Entity<Comment>().HasData(commentInit.GetComments());
        }
    }
}
