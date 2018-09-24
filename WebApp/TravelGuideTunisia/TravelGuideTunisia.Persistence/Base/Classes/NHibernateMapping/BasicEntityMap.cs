using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TravelGuideTunisia.Persistence.Base.Enums;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

namespace TravelGuideTunisia.Persistence.Base.Classes.NHibernateMapping
{
    public class BasicEntityMap<T> : ClassMap<T> where T : BasicEntity
    {
        private CompositeIdentityPart<T> _compositeId;

        //private static object _lock = new object();

        public BasicEntityMap()
            : base()
        { }

        public BasicEntityMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }

        public void AutoMap()
        {
           
            var autoMappedProperties = typeof(T).GetProperties().Where(p => Attribute.IsDefined(p, typeof(DBColumnAttribute))
                && ((DBColumnAttribute)p.GetCustomAttribute<DBColumnAttribute>()).AutoMap).ToList();



            foreach (var property in autoMappedProperties)
            {

                var propertyExpression = GetPropertyExpression(property);
                var dbColumnAttribute = property.GetCustomAttribute<DBColumnAttribute>();
                if (dbColumnAttribute.IsId)
                {
                    MapIdentifier(propertyExpression, dbColumnAttribute);
                }
                else if (dbColumnAttribute.IsCompositeId)
                {
                    MapCompositeId(propertyExpression, dbColumnAttribute);
                }
                else if (dbColumnAttribute.IsReference)
                {
                    MapReferences(propertyExpression, dbColumnAttribute);
                }
                else
                {
                    MapProperty(propertyExpression, dbColumnAttribute);
                }

            }
        }

        public void SetTable()
        {
            var dbTableAttribute = typeof(T).GetCustomAttribute<DBTableAttribute>();
            if (dbTableAttribute == null)
            {
                throw new ArgumentNullException("Table name is missing, you should add the table name to the DBTableAttribute in the Entity class to user SetTable() method or Use Table(<Table_name>) in the mapping class.");
            }
            Table(dbTableAttribute.TableName);

            if (dbTableAttribute.ReadOnly)
            {
                ReadOnly();
            }

        }

        public static Expression<Func<T, object>> GetPropertyExpression(PropertyInfo propertyInfo)
        {
            var param = Expression.Parameter(typeof(T));
            var field = Expression.Convert(Expression.Property(param, propertyInfo.Name), typeof(object));

            return Expression.Lambda<Func<T, object>>(field, param);
        }

        public static string DbColumnName<P>(Expression<Func<T, P>> propertyExpression)
        {
            var body = propertyExpression.Body;
            var memberExpressionBody = body as MemberExpression;

            if (memberExpressionBody != null)
            {
                return memberExpressionBody.Member.GetCustomAttribute<DBColumnAttribute>().DbName;
            }
            var unaryExpressionBody = body as UnaryExpression;
            if (unaryExpressionBody != null)
            {
                return ((MemberExpression)unaryExpressionBody.Operand).Member.GetCustomAttribute<DBColumnAttribute>().DbName;
            }
            throw new ArgumentException("Only UnaryExpression and MemberExpression expressions are accepted.");
        }

        #region Private Methods

        private void MapProperty(Expression<Func<T, object>> propertyExpression, DBColumnAttribute dbColumnAttribute)
        {
            var map = Map(propertyExpression, DbColumnName(propertyExpression));

            if (dbColumnAttribute.NotNullable)
                map.Not.Nullable();

            if (dbColumnAttribute.NotInsertable)
                map.Not.Insert();

            if (dbColumnAttribute.NotUpdatable)
                map.Not.Update();

            if (dbColumnAttribute.ReadOnly)
                map.ReadOnly();

            if (dbColumnAttribute.LazyLoad)
                map.LazyLoad();

            if (dbColumnAttribute.LengthHasValue)
                map.Length(dbColumnAttribute.Length);

            if (dbColumnAttribute.ScaleHasValue)
                map.Scale(dbColumnAttribute.Scale);

            if (dbColumnAttribute.Unique)
                map.Unique();

            if (!String.IsNullOrWhiteSpace(dbColumnAttribute.CustomType))
                map.CustomSqlType(dbColumnAttribute.CustomType);

            if (!String.IsNullOrWhiteSpace(dbColumnAttribute.Default))
                map.Default(dbColumnAttribute.Default);

            if (!String.IsNullOrWhiteSpace(dbColumnAttribute.Formula))
                map.Formula(dbColumnAttribute.Formula);

            if (!String.IsNullOrWhiteSpace(dbColumnAttribute.CheckConstraint))
                map.Check(dbColumnAttribute.CheckConstraint);

        }


        private void MapReferences<T2>(Expression<Func<T, T2>> propertyExpression, DBColumnAttribute dbColumnAttribute)
        {


            var references = References(propertyExpression, DbColumnName(propertyExpression));

            if (dbColumnAttribute.NotNullable)
                references.Not.Nullable();

            if (dbColumnAttribute.NotInsertable)
                references.Not.Insert();

            if (dbColumnAttribute.NotUpdatable)
                references.Not.Update();

            if (dbColumnAttribute.ReadOnly)
                references.ReadOnly();

            if (dbColumnAttribute.LazyLoad)
                references.LazyLoad();

            if (dbColumnAttribute.Unique)
                references.Unique();

            switchOnCascade(dbColumnAttribute, references);

        }



        private void MapIdentifier(Expression<Func<T, object>> propertyExpression, DBColumnAttribute dbColumnAttribute)
        {
            var id = Id(propertyExpression, DbColumnName(propertyExpression));

            if (dbColumnAttribute.NotNullable)
                id.Not.Nullable();

            if (dbColumnAttribute.LengthHasValue)
                id.Length(dbColumnAttribute.Length);

            if (dbColumnAttribute.ScaleHasValue)
                id.Scale(dbColumnAttribute.Scale);

            if (dbColumnAttribute.Unique)
                id.Unique();
            
            if (!String.IsNullOrWhiteSpace(dbColumnAttribute.CustomType))
                id.CustomType(dbColumnAttribute.CustomType);

            if (!String.IsNullOrWhiteSpace(dbColumnAttribute.Default))
                id.Default(dbColumnAttribute.Default);

            if (!String.IsNullOrWhiteSpace(dbColumnAttribute.CheckConstraint))
                id.Check(dbColumnAttribute.CheckConstraint);

            if (dbColumnAttribute.IsGeneratedByGuid)
            {
                id.GeneratedBy.Guid();
            }
            else if (!String.IsNullOrWhiteSpace(dbColumnAttribute.GeneratedBySequence))
            {
                id.GeneratedBy.Sequence(dbColumnAttribute.GeneratedBySequence);
            }
        }

        private void MapCompositeId(Expression<Func<T, object>> propertyExpression, DBColumnAttribute dbColumnAttribute)
        {
            var keyPropertyAction = getKeyPropertyAction(propertyExpression, dbColumnAttribute);
            if (_compositeId == null)
            {
                if (dbColumnAttribute.IsReference)
                {
                    _compositeId = CompositeId().KeyReference(propertyExpression, dbColumnAttribute.ReferenceColumnsNames);
                }
                else
                {
                    _compositeId = CompositeId().KeyProperty(propertyExpression, keyPropertyAction);
                }

            }
            else
            {
                if (dbColumnAttribute.IsReference)
                {
                    _compositeId.KeyReference(propertyExpression, dbColumnAttribute.ReferenceColumnsNames);
                }
                else
                {
                    _compositeId.KeyProperty(propertyExpression, keyPropertyAction);
                }

            }
        }

        private static Action<KeyPropertyPart> getKeyPropertyAction(Expression<Func<T, object>> propertyExpression, DBColumnAttribute dbColumnAttribute)
        {
            return id =>
            {
                id.ColumnName(DbColumnName(propertyExpression));
                if (dbColumnAttribute.LengthHasValue)
                    id.Length(dbColumnAttribute.Length);
                if (!String.IsNullOrWhiteSpace(dbColumnAttribute.CustomType))
                    id.Type(dbColumnAttribute.CustomType);

            };
        }

        private static void switchOnCascade<T2>(DBColumnAttribute dbColumnAttribute, ManyToOnePart<T2> references)
        {
            switch (dbColumnAttribute.Cascade)
            {
                case CascadeBehavior.None:
                    { references.Cascade.None(); }
                    break;

                case CascadeBehavior.Delete:
                    { references.Cascade.Delete(); }
                    break;

                case CascadeBehavior.SaveUpdate:
                    { references.Cascade.SaveUpdate(); }
                    break;

                case CascadeBehavior.Merge:
                    { references.Cascade.Merge(); }
                    break;

                case CascadeBehavior.Replicate:
                    { references.Cascade.Replicate(); }
                    break;

                case CascadeBehavior.All:
                    { references.Cascade.All(); }
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}
