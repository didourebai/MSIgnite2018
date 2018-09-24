namespace TravelGuideTunisia.Business.Models.SMSCheck
{
    public class PostCodeSMSResultModel
    {

        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Code Length
        /// </summary>
        public int CodeLength { get; set; }

        /// <summary>
        /// Time To Live
        /// </summary>
        public string Ttl { get; set; }

        /// <summary>
        /// Message Template
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the message u identifier.
        /// </summary>
        /// <value>
        /// The message u identifier.
        /// </value>
        public string MessageUId { get; set; }
    }
}
