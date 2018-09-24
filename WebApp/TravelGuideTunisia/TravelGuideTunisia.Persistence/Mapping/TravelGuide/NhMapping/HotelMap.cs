using TravelGuideTunisia.Persistence.Base.Classes.NHibernateMapping;
using TravelGuideTunisia.Persistence.Entities.TravelGuide;

namespace TravelGuideTunisia.Persistence.Mapping.TravelGuide.NhMapping
{
    public class HotelMap : BasicEntityMap<Hotel>, ITravelGuideMap
    {
        public HotelMap()
        {
            Id(x => x.Id).Column("Id");
            Map(x => x.Title).Column("Title");

            References(x => x.Place)
                .LazyLoad()
                .Not.Nullable()
                .ReadOnly()
                .Column("Place");
        }
    }
}
