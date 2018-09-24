namespace TravelGuideTunisia.Business.Models.SMSCheck
{
    public class SMSToSendModel
    {
        public string ServiceUrl { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string CallbackURL { get; set; }
        public string RequestUid { get; set; } //TODO ADD IT in the DB
        public string MessageToSend { get; set; }

        public string AppId { get; set; }
    }
}
