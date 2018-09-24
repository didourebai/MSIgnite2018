using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TravelGuideTunisia.Persistence.Base.QueryCriteria
{
    public class InCriterion<A> : IQueryCriterion
    {
        public string PropertyName
        {
            get
            {
                return PropertyExpression.Body is UnaryExpression
                ? ((MemberExpression)((UnaryExpression)PropertyExpression.Body).Operand).Member.Name
                : ((MemberExpression)(PropertyExpression.Body)).Member.Name;
            }
        }


        public IEnumerable<A> Values { get; set; }


        public Expression<Func<A, object>> PropertyExpression { get; set; }


        public InCriterion(Expression<Func<A, object>> propertyExpression, IEnumerable<A> values)
        {
            Values = values;

            PropertyExpression = propertyExpression;
        }
    }
}
