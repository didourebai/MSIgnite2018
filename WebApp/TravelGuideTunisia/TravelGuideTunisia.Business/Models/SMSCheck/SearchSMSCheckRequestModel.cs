using System;

namespace TravelGuideTunisia.Business.Models.SMSCheck
{
    public class SearchSMSCheckRequestModel
    {
        public string Id { get; set; }


        public string UserId { get; set; }


        public string AppId { get; set; }


        public uint PhoneNumber { get; set; }


        public string ValidationStatus { get; set; }


        public string SentStatus { get; set; }


        public DateTime ExpirationTime { get; set; }


        public int SmsCode { get; set; }
    }
}