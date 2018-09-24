using System.Collections.Generic;

namespace TravelGuideTunisia.Persistence.Base.QueryCriteria
{
    public class Junction : IQueryCriterion
    {
        public List<IQueryCriterion> Criteria { get; private set; }

        public Junction()
        {
            Criteria = new List<IQueryCriterion>();
        }

        public void Add(IQueryCriterion criterion)
        {
            Criteria.Add(criterion);
        }

        public void AddRange(List<IQueryCriterion> criteria)
        {
            Criteria.AddRange(criteria);
        }
    }
}
