using TravelGuideTunisia.Persistence.Base.Classes;

namespace TravelGuideTunisia.Persistence.Entities.TravelGuide
{
    [DBTable("User")]
    public class User : BasicEntity, ITravelGuide
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        [DBColumn("UserName", AutoMap = true, IsId = true, Length = MaxTitleLength)]
        public virtual string UserName { get; set; }

        [DBColumn("Name", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Name { get; set; }

        [DBColumn("Descritpion", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Surname { get; set; }

        [DBColumn("EmailAddress", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string EmailAddress { get; set; }

        [DBColumn("Password", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Password { get; set; }

        [DBColumn("IsEmailConfirmed", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual bool IsEmailConfirmed { get; set; }

        [DBColumn("IsActive", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual bool IsActive { get; set; }
    }
}
