using System;
using System.Linq.Expressions;

namespace TravelGuideTunisia.Persistence.Base.QueryCriteria
{
    public class LessThanCriterion<A> : IQueryCriterion
    {
        public Expression<Func<A, object>> PropertyExpression { get; set; }

        public object Value { get; set; }

        public bool AcceptEqual { get; set; }

        public string PropertyName
        {
            get
            {
                return PropertyExpression.Body is UnaryExpression
                ? ((MemberExpression)((UnaryExpression)PropertyExpression.Body).Operand).Member.Name
                : ((MemberExpression)(PropertyExpression.Body)).Member.Name;
            }
        }

        public LessThanCriterion(Expression<Func<A, object>> expression, object value)
        {
            PropertyExpression = expression;
            Value = value;
        }


        public LessThanCriterion(Expression<Func<A, object>> expression, object value, bool acceptEqual)
        {
            PropertyExpression = expression;
            Value = value;
            AcceptEqual = acceptEqual;
        }
    }
}
