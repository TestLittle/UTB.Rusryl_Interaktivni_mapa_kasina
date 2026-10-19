using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class LocationKindInit
    {
        public IList<LocationKind> GetLocationKinds()
        {
            IList<LocationKind> locationKinds = new List<LocationKind>();

            locationKinds.Add(new LocationKind()
            {
                Id = 1,
                LocationKindName = "obchod"
            });

            locationKinds.Add(new LocationKind()
            {
                Id = 2,
                LocationKindName = "monument"
            });

            locationKinds.Add(new LocationKind()
            {
                Id = 3,
                LocationKindName = "kasino"
            });

            locationKinds.Add(new LocationKind()
            {
                Id = 4,
                LocationKindName = "knihovna"
            });

            locationKinds.Add(new LocationKind()
            {
                Id = 5,
                LocationKindName = "hotel"
            });

            return locationKinds;
        }
    }
}