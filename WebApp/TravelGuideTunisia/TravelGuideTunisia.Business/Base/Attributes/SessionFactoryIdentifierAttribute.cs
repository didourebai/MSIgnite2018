using System;

namespace TravelGuideTunisia.Business.Base.Attributes
{
    public class SessionFactoryIdentifierAttribute : Attribute
    {
        public string SessionFactoryIdentifire;

        public SessionFactoryIdentifierAttribute()
        { }

        public SessionFactoryIdentifierAttribute(string sessionFactoryKey)
        {
            SessionFactoryIdentifire = sessionFactoryKey;
        }
    }
}
