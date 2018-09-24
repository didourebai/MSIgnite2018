using TravelGuideTunisia.Persistence.Base.Classes.NHibernateMapping;

namespace TravelGuideTunisia.Persistence.Mapping.TravelGuide.NhMapping
{
    public class UserMap : BasicEntityMap<Entities.TravelGuide.User> , ITravelGuideMap
    {
        public UserMap()
        {
            AutoMap();
            SetTable();
        }
    }
}
