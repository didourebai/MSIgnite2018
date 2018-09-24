using TravelGuideTunisia.Business.Validation;

namespace TravelGuideTunisia.Business.Models.SMSCheck
{
    public class CodeCheckRequestModel : SelfValidationModel
    {
        /// <summary>
        /// Application ID
        /// </summary>
        [Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        [Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Code to be verified
        /// </summary>
        [Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_code")]
        public string Code { get; set; }
    }
}
