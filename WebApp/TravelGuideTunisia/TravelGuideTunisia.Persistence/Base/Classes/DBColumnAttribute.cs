using System;
using TravelGuideTunisia.Persistence.Base.Enums;

namespace TravelGuideTunisia.Persistence.Base.Classes
{
    public class DBColumnAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public string DbName { get; set; }

        public bool AutoMap { get; set; }

        public bool IsId { get; set; }

        public bool IsCompositeId { get; set; }

        public bool IsDefaultOrderProperty { get; set; }

        public bool NotNullable { get; set; }

        public bool NotInsertable { get; set; }

        public bool NotUpdatable { get; set; }

        public bool ReadOnly { get; set; }

        public string CustomType { get; set; }

        public bool LazyLoad { get; set; }

        public bool Unique { get; set; }

        public string Default { get; set; }

        public bool IsGeneratedByGuid { get; set; }

        public string Formula { get; set; }

        public string CheckConstraint { get; set; }

        public string GeneratedBySequence { get; set; }



        public int Length { get { return length.Value; } set { length = value; } }

        public int Scale { get { return scale.Value; } set { scale = value; } }

        public bool LengthHasValue { get { return length.HasValue; } }

        public bool ScaleHasValue { get { return scale.HasValue; } }

        public bool IsReference { get; set; }

        public string[] ReferenceColumnsNames { get; set; }

        public CascadeBehavior Cascade { get; set; }

        private int? length { get; set; }

        private int? scale { get; set; }



        public DBColumnAttribute()
        {

        }

        public DBColumnAttribute(string propertyName, string dbName)
        {
            PropertyName = propertyName;
            DbName = dbName;
        }

        public DBColumnAttribute(string dbName)
        {
            DbName = dbName;
        }

    }
}
