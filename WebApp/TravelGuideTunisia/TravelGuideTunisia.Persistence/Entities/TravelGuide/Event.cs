using System;
using System.Collections.Generic;
using TravelGuideTunisia.Persistence.Base.Classes;

namespace TravelGuideTunisia.Persistence.Entities.TravelGuide
{
    [DBTable("Event")]
    public class Event : BasicEntity, ITravelGuide
    {
        public const int MaxTitleLength = 128; 
        public const int MaxDescriptionLength = 2048;

        [DBColumn("Id", AutoMap = true, IsId = true, Length = 4)]
        public virtual string Id { get; set; }

        [DBColumn("Descritpion", AutoMap = true, NotNullable = true, Length = MaxDescriptionLength)]
        public virtual string Descritpion { get; set; }

        [DBColumn("Title", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Title { get; set; }

        [DBColumn("Address", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Address { get; set; }

        [DBColumn("Governate", AutoMap = true, NotNullable = true, Length = MaxTitleLength)]
        public virtual string Governate { get; set; }

        [DBColumn("Date", AutoMap = true, NotNullable = true)]
        public virtual DateTime Date { get;  set; }

        [DBColumn("IsCancelled", AutoMap = true, NotNullable = true)]
        public virtual bool IsCancelled { get;  set; }

        [DBColumn("MaxRegistrationCount", AutoMap = true, NotNullable = true)]
        public virtual int MaxRegistrationCount { get;  set; }

        //[DBColumn("MaxRegistrationCount", AutoMap = true, IsReference = true, ReferenceColumnsNames = new []{ "Id"  })]
        //public virtual IList<EventRegistration> Registrations { get;  set; }

    }
}
