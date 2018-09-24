using System;

namespace TravelGuideTunisia.Business.Validation
{
    /// <summary>
    /// This is an abstract Validation attribute.
    /// All the other validation attributes must inherit form it. 
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public abstract class ValidationAttribute : System.Attribute
    {
        #region Read-only Arguments

        #endregion


        #region Accessors

        #endregion


        #region Named Arguments

        private string _failureMessage;

        /// <summary>
        /// Gets or sets the failure message that will be returned in case of validation failure.
        /// </summary>
        /// <value>
        /// The failure message.
        /// </value>
        public string FailureMessage
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(FailureMessageKeyInAppSettings))
                {
                    _failureMessage = System.Configuration.ConfigurationManager.AppSettings.Get(FailureMessageKeyInAppSettings) ?? _failureMessage;
                }
                return _failureMessage;
            }
            set
            {
                _failureMessage = value;
            }
        }

        private string _failureMessageKeyInAppSettings;

        /// <summary>
        /// Gets or sets the failure message key in application settings.
        /// The Key refers to a failure message added in the application settings in the configuration file.
        /// The failure message will be returned in case of validation failure.
        /// </summary>
        /// <value>
        /// The failure message key in application settings.
        /// </value>
        public string FailureMessageKeyInAppSettings
        {
            get
            {
                return String.IsNullOrWhiteSpace(_failureMessageKeyInAppSettings) ? null : _failureMessageKeyInAppSettings;
            }

            set
            {
                _failureMessageKeyInAppSettings = value;
            }
        }
        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationAttribute"/> class.
        /// </summary>
        public ValidationAttribute()
        {

        }
        #endregion


        #region Public Methods        
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public virtual bool Validate(object value)
        {
            if (!string.IsNullOrWhiteSpace(FailureMessageKeyInAppSettings))
            {
                FailureMessage = System.Configuration.ConfigurationManager.AppSettings.Get(FailureMessageKeyInAppSettings) ?? FailureMessage;
            }
            return true;
        }
        #endregion

    }
}
