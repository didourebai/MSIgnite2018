namespace TravelGuideTunisia.Business.Models.SMSCheck
{
    public class SMSSentResultModel
    {
        public string MessageUId { get; set; }

        public bool IsMessageSent { get { return !string.IsNullOrWhiteSpace(MessageUId); } }
    }
}
