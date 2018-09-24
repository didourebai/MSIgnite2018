using System.Collections.Generic;

namespace TravelGuideTunisia.Business.Models
{
    public class ResultListModel<T> where T : class
    {
        public IList<T> Items { get; set; }
        public Pagination PaginationHeader { get; set; }

        public ResultListModel()
        {
            Items = new List<T>();
            PaginationHeader = new Pagination();
        }

        public ResultListModel(List<T> items)
        {
            Items = items;
            PaginationHeader = new Pagination();
        }

        public ResultListModel(int absoluteTotalCount, int totalCount, int totalPages)
        {
            Items = new List<T>();
            PaginationHeader = new Pagination(absoluteTotalCount, totalCount, totalPages);
        }

        public ResultListModel(List<T> items, int absoluteTotalCount, int totalCount, int totalPages)
        {
            Items = items;
            PaginationHeader = new Pagination(absoluteTotalCount, totalCount, totalPages);
        }
    }
}
