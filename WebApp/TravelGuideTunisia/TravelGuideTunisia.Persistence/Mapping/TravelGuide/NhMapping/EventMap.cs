using TravelGuideTunisia.Persistence.Base.Classes.NHibernateMapping;

namespace TravelGuideTunisia.Persistence.Mapping.TravelGuide.NhMapping
{
    public class EventMap : BasicEntityMap<Entities.TravelGuide.Event> , ITravelGuideMap
    {
        public EventMap()
        {
            AutoMap();
            SetTable();
        }
    }
}
