using System;

namespace TravelGuideTunisia.Business.Validation
{
    /// <summary>
    /// This validation attribute is responsible for checking the existence of the mandatory property.
    /// </summary>
    /// <seealso cref="NeoSIR.Domain.Validation.ValidationAttribute" />
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class Mandatory : ValidationAttribute
    {
        #region Read-only Arguments

        #endregion

        #region Accessors

        #endregion

        #region Named Arguments



        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Mandatory"/> class.
        /// </summary>
        public Mandatory()
        {

        }

        #endregion

        #region Public Methods        
        /// <summary>
        /// Validates the specified value. It check its existence.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns true if the mandatory value exists, false otherwise.</returns>
        public override bool Validate(object value)
        {
            return value != null && (!(value is string) || !string.IsNullOrWhiteSpace(value.ToString()));
        }
        #endregion
    }
}
