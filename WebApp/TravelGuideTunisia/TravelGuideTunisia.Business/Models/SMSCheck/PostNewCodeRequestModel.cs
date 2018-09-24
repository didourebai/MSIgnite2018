using TravelGuideTunisia.Business.Validation;

namespace TravelGuideTunisia.Business.Models.SMSCheck
{
    public class PostNewCodeRequestModel : SelfValidationModel
    {

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        //[Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        //[Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        //[Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_phone_number")]
        //[Pattern(FailureMessageKeyInAppSettings = "failure_message_pattern_phone_number", PatternStringKeyInAppSettings = "pattern_phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the length of the code.
        /// </summary>
        /// <value>
        /// The length of the code.
        /// </value>
        //[Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_code_length")]
        public int? CodeLength { get; set; }

        /// <summary>
        /// Gets or sets the Code Time To Live.
        /// </summary>
        /// <value>
        /// The Time To Live.
        /// </value>
        //[Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_code_ttl")]
        public int? Ttl { get; set; }

        /// <summary>
        /// Gets or sets the message template.
        /// </summary>
        /// <value>
        /// The message template.
        /// </value>
        //[Mandatory(FailureMessageKeyInAppSettings = "failure_message_mandatory_message_template")]
        public string MessageTemplate { get; set; }
    }
}
