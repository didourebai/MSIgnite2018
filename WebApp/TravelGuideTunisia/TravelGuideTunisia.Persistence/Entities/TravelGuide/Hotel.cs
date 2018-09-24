using TravelGuideTunisia.Persistence.Base.Classes;

namespace TravelGuideTunisia.Persistence.Entities.TravelGuide
{
    [DBTable("Hotel")]
    public class Hotel : BasicEntity, ITravelGuide
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        [DBColumn("Id", AutoMap = true, IsId = true, Length = 4)]
        public virtual string Id { get; set; }

        [DBColumn("Title", AutoMap = true, NotNullable = true, Length = MaxDescriptionLength)]
        public virtual string Title { get; set; }

        [DBColumn("Place", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual Place Place { get; set; }
    }
}
