using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class LocationInit
    {
        public IList<Location> GetLocations()
        {
            IList<Location> locations = new List<Location>();

            locations.Add(new Location()
            {
               Id = 1,
               Name = "Hotel Karlovický Svět",
               ImageSrc = "/img/location/hotel-karlovicky-svet.jpg",
               Address = "Karlovická 668/25",
               CoordsOnMap = "628.25, 365.22",
               LocationTypeId = 1,
               LocationKindId = 5
            });

            locations.Add(new Location()
            {
               Id = 2,
               Name = "Velké Výhry",
               ImageSrc = "/img/location/velke-vyhry.jpg",
               Address = "Hrací 421/15",
               CoordsOnMap = "503.11, 505.52",
               LocationTypeId = 2,
               LocationKindId = 3
            });

            locations.Add(new Location()
            {
               Id = 3,
               Name = "Grantova brána",
               ImageSrc = "/img/location/grantova-brana.jpg",
               Address = "Branická 422/31",
               CoordsOnMap = "425.02, 805.05",
               LocationTypeId = 1,
               LocationKindId = 2
            });

            locations.Add(new Location()
            {
               Id = 4,
               Name = "Světnická Národní Knihovna",
               ImageSrc = "/img/location/svetnicka-narodni-knihovna.jpg",
               Address = "Univerzitní 402/44",
               CoordsOnMap = "805.80, 580.05",
               LocationTypeId = 1,
               LocationKindId = 4
            });

            locations.Add(new Location()
            {
               Id = 5,
               Name = "U Květy",
               ImageSrc = "/img/location/u-kvety.jpg",
               Address = "Obchodní 450/27",
               CoordsOnMap = "40.25, 80.50",
               LocationTypeId = 1,
               LocationKindId = 1
            });

            return locations;
        }
    }
}