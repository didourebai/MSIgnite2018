using System;

namespace TravelGuideTunisia.Business.Models.SMSCheck
{
    /// <summary>
    /// RateControlModel Class
    /// </summary>
    public class RateControlModel
    {
        /// <summary>
        /// App Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }



        /// <summary>
        /// Creation Date Time
        /// </summary>
        public DateTime? CreationTime { get; set; }
    }
}
