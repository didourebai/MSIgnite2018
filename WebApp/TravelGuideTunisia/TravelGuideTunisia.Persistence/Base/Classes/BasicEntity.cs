using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TravelGuideTunisia.Persistence.Base.Classes
{
    public class BasicEntity
    {
        [DBColumn("LAST_MODIFICATION_DATE",PropertyName = "LastModificationDate", IsDefaultOrderProperty = true)]
        public virtual DateTime? UpdatedTime { get; set; }

        [DBColumn("CREATION_DATE", PropertyName = "CreationDate")]
        public virtual DateTime? CreationTime { get; set; }



        public virtual bool Equals<E>(object obj) where E : BasicEntity
        {
            if (this.GetType().GetProperties().Any(isCompositeId()))
            {
                var e = obj as E;

                return e != null && checkEqualId<E>(e);
            }

            return base.Equals(obj);
        }

        public virtual int GetHashCode<E>()
        {
            if (this.GetType().GetProperties().Any(isCompositeId()))
            {

                return getComposedHashCode<E>();
            }

            return base.GetHashCode();
        }


        public virtual PropertyInfo GetDefaultOrderByProperty()
        {
            return Attribute.IsDefined(GetType(), typeof(DBColumnAttribute))
                ? GetType().GetProperties().Where(p => p.GetCustomAttribute<DBColumnAttribute>().IsDefaultOrderProperty).FirstOrDefault()
                : null;
        }

        #region Private Methods
        private bool checkEqualId<E>(E e)
        {

            var compositeIdsList = getCompositeIdList<E>();

            foreach (var cid in compositeIdsList)
            {
                if (cid.GetValue(this) != cid.GetValue(e))
                {
                    return false;
                }
            }
            return true;
        }

        private int getComposedHashCode<E>()
        {
            var compositeIdList = getCompositeIdList<E>();
            var hashCodeBuilder = new StringBuilder(compositeIdList[0].GetValue(this).ToString());
            for (int i = 0; i < compositeIdList.Count; i++)
            {
                hashCodeBuilder.Append("|" + compositeIdList[i].GetValue(this) as String);
            }
            return hashCodeBuilder.ToString().GetHashCode();
        }

        private static List<PropertyInfo> getCompositeIdList<E>()
        {
            return typeof(E).GetProperties().Where(isCompositeId()).ToList();
        }

        private static Func<PropertyInfo, bool> isCompositeId()
        {
            return p => Attribute.IsDefined(p, typeof(DBColumnAttribute))
                            && ((DBColumnAttribute)p.GetCustomAttribute<DBColumnAttribute>()).IsCompositeId;
        }

        public virtual void SetDefaultValues()
        {
            var defaultValueProperties = this.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(DBColumnAttribute))
                            && ((DBColumnAttribute)p.GetCustomAttribute<DBColumnAttribute>()).AutoMap && !String.IsNullOrWhiteSpace(((DBColumnAttribute)p.GetCustomAttribute<DBColumnAttribute>()).Default)).ToList();

            foreach (var prop in defaultValueProperties)
            {
                //var propType = prop.GetType();

                //propType.is
                var isNullable = prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);

                var propTypeName = isNullable ? prop.PropertyType.GenericTypeArguments[0].Name : prop.PropertyType.Name;

                var stringValue = prop.GetCustomAttribute<DBColumnAttribute>().Default;
                switch (propTypeName)
                {
                    case "Int16":
                        {

                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, Int16.Parse(stringValue));


                        }
                        break;

                    case "Int32":
                        {
                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, Int32.Parse(stringValue));
                        }
                        break;

                    case "Int64":
                        {
                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, Int64.Parse(stringValue));
                        }
                        break;

                    case "String":
                        {
                            if (prop.GetValue(this) == null || String.IsNullOrWhiteSpace((string)prop.GetValue(this)))
                                prop.SetValue(this, stringValue);
                        }
                        break;

                    case "Char":
                        {
                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, Char.Parse(stringValue));
                        }
                        break;

                    case "DateTime":
                        {
                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, DateTime.Parse(stringValue));
                        }
                        break;

                    case "Single":
                        {
                            prop.SetValue(this, Single.Parse(stringValue));
                        }
                        break;

                    case "Decimal":
                        {
                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, Decimal.Parse(stringValue));
                        }
                        break;

                    case "Double":
                        {
                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, Double.Parse(stringValue));
                        }
                        break;

                    case "Boolean":
                        {
                            if (prop.GetValue(this) == null)
                                prop.SetValue(this, Boolean.Parse(stringValue));
                        }
                        break;

                    default:
                        break;
                }

            }

        }

        #endregion
    }
}
