using TravelGuideTunisia.Persistence.Base.Classes;

namespace TravelGuideTunisia.Persistence.Entities.TravelGuide
{
    [DBTable("Place")]
    public class Place : BasicEntity, ITravelGuide
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        [DBColumn("Id", AutoMap = true, IsId = true, Length = 4)]
        public virtual string Id { get; set; }

        [DBColumn("Descritpion", AutoMap = true, NotNullable = true, Length = MaxDescriptionLength)]
        public virtual string Descritpion { get; set; }

        [DBColumn("Governorate", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Governorate { get; set; }

        [DBColumn("Address", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Address { get; set; }

        [DBColumn("History", AutoMap = true, NotNullable = true, Length = MaxDescriptionLength)]
        public virtual string History { get; set; }
    }
}
