namespace TravelGuideTunisia.Persistence.Base.QueryCriteria
{
    public class NotCriterion<A> : IQueryCriterion
    {
        public IQueryCriterion Criterion { get; private set; }


        public NotCriterion(IQueryCriterion criterion)
        {
            Criterion = criterion;
        }
    }
}
