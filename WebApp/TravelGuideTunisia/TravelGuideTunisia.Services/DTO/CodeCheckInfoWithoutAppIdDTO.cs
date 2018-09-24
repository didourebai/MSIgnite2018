using Newtonsoft.Json;

namespace TravelGuideTunisia.Services.DTO
{
    public class CodeCheckInfoWithoutAppIdDTO
    {
        /// <summary>
        /// User Id
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Code to be verified
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
