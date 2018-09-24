using TravelGuideTunisia.Persistence.Base.Classes.NHibernateMapping;

namespace TravelGuideTunisia.Persistence.Mapping.TravelGuide.NhMapping
{
    public class PlaceMap : BasicEntityMap<Entities.TravelGuide.Place> , ITravelGuideMap
    {
        public PlaceMap()
        {
            AutoMap();
            SetTable();
        }
    }
}
