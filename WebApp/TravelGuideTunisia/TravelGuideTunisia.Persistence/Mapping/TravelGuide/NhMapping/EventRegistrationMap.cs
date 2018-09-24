using TravelGuideTunisia.Persistence.Base.Classes.NHibernateMapping;

namespace TravelGuideTunisia.Persistence.Mapping.TravelGuide.NhMapping
{
    public class EventRegistrationMap : BasicEntityMap<Entities.TravelGuide.EventRegistration>, ITravelGuideMap
    {
        public EventRegistrationMap()
        {
            //AutoMap();
            //SetTable();

            Id(x => x.Id).Column("Id");

            References(x => x.Event)
                .LazyLoad()
                .Not.Nullable()
                .ReadOnly()
                .Column("Event");

            References(x => x.User)
                .LazyLoad()
                .Not.Nullable()
                .ReadOnly()
                .Column("User");

            Table("EventRegistration");
        }
    }
}

