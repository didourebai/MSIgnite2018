using System;
using System.Linq.Expressions;
using System.Reflection;
using TravelGuideTunisia.Persistence.Base.Classes;

namespace TravelGuideTunisia.Business.Helpers
{
    public class AttributesResolver<T> where T : class
    {
        #region Criteria Attribute resolver
        public static string GetCriteriaPropertyByName(string name)
        {
            var properties = typeof(T).GetProperties();


            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(DBColumnAttribute)) as DBColumnAttribute;
                if (attribute != null && string.Equals(name, attribute.PropertyName))
                {
                    return property.Name;
                }
            }

            return null;
        }




        public static Type GetCriteriaPropertyTypeByName(string name)
        {
            var properties = typeof(T).GetProperties();


            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(DBColumnAttribute)) as DBColumnAttribute;
                if (attribute != null && string.Equals(name, attribute.PropertyName))
                {
                    return property.PropertyType;
                }
            }

            return null;
        }

        public static string GetCriteriaDefaultOrderProperty()
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(DBColumnAttribute)) as DBColumnAttribute;
                if (attribute != null && attribute.IsDefaultOrderProperty)
                {
                    return property.Name;
                }
            }

            return null;
        }

        public static string GetPropertyName<P>(Expression<Func<T, P>> propertyExpression)
        {
            return ((MemberExpression)propertyExpression.Body).Member.Name;
        }
        #endregion

    }
}
