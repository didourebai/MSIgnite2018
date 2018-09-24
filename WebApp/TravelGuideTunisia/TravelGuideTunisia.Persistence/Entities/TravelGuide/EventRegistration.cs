using TravelGuideTunisia.Persistence.Base.Classes;

namespace TravelGuideTunisia.Persistence.Entities.TravelGuide
{
    [DBTable("EventRegistration")]
    public class EventRegistration : BasicEntity, ITravelGuide
    {
        [DBColumn("Id", AutoMap = true, IsId = true, Length = 4)]
        public virtual string Id { get; set; }

        [DBColumn("UserName", AutoMap = true, NotNullable = true, IsReference = true)]
        public virtual User User { get;  set; }

        [DBColumn("Event", AutoMap = true, NotNullable = true, IsReference = true)]
        public virtual Event Event { get;  set; }
    }
}
