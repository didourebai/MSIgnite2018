using System;

namespace TravelGuideTunisia.Persistence.Base.Classes
{
    public class DBTableAttribute : Attribute
    {
        public string TableName { get; set; }

        private bool _isReadOnly;

        public bool ReadOnly
        {
            get { return IsView || _isReadOnly; }
            set { _isReadOnly = value; }
        }

        public bool IsView { get; set; }


        #region Constructors

        public DBTableAttribute() { }

        public DBTableAttribute(string name)
        {
            TableName = name;
        }

        #endregion

    }
}
