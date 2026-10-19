using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class LocationTypeInit
    {
        public IList<LocationType> GetLocationTypes()
        {
            IList<LocationType> locationTypes = new List<LocationType>();

            locationTypes.Add(new LocationType() {
                Id = 1,
                LocationTypeName = "location"
            });

            locationTypes.Add(new LocationType()
            {
                Id = 2,
                LocationTypeName = "interactive"
            });
            
            return locationTypes;
        }
    }
}