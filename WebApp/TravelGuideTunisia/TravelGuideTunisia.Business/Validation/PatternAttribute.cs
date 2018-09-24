using System;
using System.Text.RegularExpressions;

namespace TravelGuideTunisia.Business.Validation
{
    /// <summary>
    /// This validation attribute is responsible for validate a string property regarding a specified pattern.
    /// </summary>
    /// <seealso cref="NeoSIR.Domain.Validation.ValidationAttribute" />
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class Pattern : ValidationAttribute
    {
        #region Read-only Arguments

        #endregion

        #region Accessors        
        /// <summary>
        /// Gets or sets the pattern string.
        /// </summary>
        /// <value>
        /// The pattern string that will be used for validation.
        /// </value>
        public string PatternString { get; set; }

        /// <summary>
        /// Gets or sets the pattern string key in application settings.
        /// The Key refers to a pattern added in the application settings in the configuration file.
        /// this pattern will be used for validation.
        /// </summary>
        /// <value>
        /// The pattern string key in application settings.
        /// </value>
        public string PatternStringKeyInAppSettings { get; set; }

        #endregion

        #region Named Arguments

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Pattern"/> class.
        /// </summary>
        public Pattern()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pattern"/> class.
        /// </summary>
        /// <param name="patternString">The pattern string.</param>
        public Pattern(string patternString)
        {
            PatternString = patternString;

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Validates the specified value using the specified pattern.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if the value is conform to the pattern, false otherwise.</returns>
        public override bool Validate(object value)
        {
            //base.Validate(value);
            if (!String.IsNullOrWhiteSpace(PatternStringKeyInAppSettings))
            {
                PatternString = System.Configuration.ConfigurationManager.AppSettings.Get(PatternStringKeyInAppSettings) ?? PatternString;
            }
            return value == null || Regex.IsMatch(value.ToString(), PatternString);
        }
        #endregion
    }
}
