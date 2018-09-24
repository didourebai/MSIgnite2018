using System;

namespace TravelGuideTunisia.Business.Models.Event
{
    public class EventResultModel
    {
        public string Id { get; set; }
        public string Descritpion { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Governate { get; set; }
        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
    }
}
