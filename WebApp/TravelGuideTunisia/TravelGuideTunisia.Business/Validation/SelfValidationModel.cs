using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TravelGuideTunisia.Business.Validation
{
    public abstract class SelfValidationModel
    {

        private bool _isNotValid;
        public bool AutoValidation_IsNotValid
        {
            get
            {
                _errorMessage = Validate();
                return _isNotValid;
            }
        }

        private string _errorMessage;
        public string AutoValidation_ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
        }

        #region Public Methods
        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="isModelValid">An out parameter, it returns as true if the model is valid, false otherwise.</param>
        /// <returns>A list of 0 or more validation errors</returns>
        public virtual IList<string> Validate(out bool isModelValid)
        {
            var failureMessages = new List<string>();
            var failureMessage = String.Empty;
            var propertiesToValidate = this.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(ValidationAttribute)));
            isModelValid = true;
            foreach (var property in propertiesToValidate)
            {
                var isPropertyValid = validateRequirement<Mandatory>(property, ref isModelValid, failureMessages)
                                    && validateRequirement<Pattern>(property, ref isModelValid, failureMessages);
            }
            return failureMessages;
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <returns>Returns all the error messages concatenated in a single message, or null if the model is valid.</returns>
        public virtual string Validate()
        {
            var failureMessages = new List<string>();
            var failureMessage = String.Empty;
            var propertiesToValidate = this.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(ValidationAttribute)));
            bool isModelValid = true;
            foreach (var property in propertiesToValidate)
            {
                var isPropertyValid = validateRequirement<Mandatory>(property, ref isModelValid, failureMessages)
                                    && validateRequirement<Pattern>(property, ref isModelValid, failureMessages);
            }
            
            if (_isNotValid = failureMessages.Count > 0)
            {
                var errorMessageBuilder = new StringBuilder();
                foreach (var error in failureMessages)
                {
                    errorMessageBuilder.AppendFormat("{0}\r\n", error);
                }
                return errorMessageBuilder.ToString();
            }
            return null;
        }

        /// <summary>
        /// Validates the model regarding a specific <see cref=" ValidationAttribute"/>.
        /// </summary>
        /// <typeparam name="VA">The ValidationAttribute</typeparam>
        /// <param name="isValid">An out parameter, it returns as true if the model is valid, false otherwise.</param>
        /// <returns>A list of 0 or more validation errors</returns>
        public virtual IList<string> Validate<VA>(out bool isValid) where VA : ValidationAttribute
        {
            var failureMessages = new List<string>();
            var failureMessage = String.Empty;
            var propertiesToValidate = this.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(VA)));
            isValid = true;
            foreach (var property in propertiesToValidate)
            {
                var isPropertyValid = validateRequirement<VA>(property, ref isValid, failureMessages);

            }
            return failureMessages;
        }

        /// <summary>
        /// Validates the model regarding <see cref="Mandatory"/>.
        /// </summary>
        /// <param name="isValid">An out parameter, it returns as true if the model is valid, false otherwise.</param>
        /// <returns>A list of 0 or more validation errors</returns>
        public virtual IList<string> ValidateMandatories(out bool isValid)
        {
            return Validate<Mandatory>(out isValid);
        }

        /// <summary>
        /// Validates the model regarding PatternAttribute
        /// </summary>
        /// <param name="isValid">An out parameter, it returns as true if the model is valid, false otherwise.</param>
        /// <returns>A list of 0 or more validation errors</returns>
        public virtual IList<string> ValidatePatterns(out bool isValid)
        {
            return Validate<Pattern>(out isValid);
        }

        /// <summary>
        /// Validates the model regarding to <see cref="Pattern"/> attribute.
        /// </summary>
        /// <returns>Returns all the error messages concatenated in a single message, or null if the model is valid.</returns>
        public virtual string ValidatePatterns()
        {
            bool isValid;
            var failureMessages = Validate<Pattern>(out isValid);
            if (failureMessages.Count > 0)
            {
                var errorMessageBuilder = new StringBuilder();
                foreach (var error in failureMessages)
                {
                    errorMessageBuilder.AppendFormat("{0}\r\n", error);
                }
                return errorMessageBuilder.ToString();
            }
            return null;
        }

        /// <summary>
        /// Validates the model regarding <see cref="Mandatory"/> attribute.
        /// </summary>
        /// <returns></returns>
        public virtual string ValidateMandatories()
        {
            bool isValid;
            var failureMessages = Validate<Mandatory>(out isValid);
            if (failureMessages.Count > 0)
            {
                var errorMessageBuilder = new StringBuilder();
                foreach (var error in failureMessages)
                {
                    errorMessageBuilder.AppendFormat("{0}\r\n", error);
                }
                return errorMessageBuilder.ToString();
            }
            return null;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Validates a specific model property, regarding a specific <see cref="ValidationAttribute"/>.
        /// </summary>
        /// <typeparam name="VA">The type of the <see cref="ValidationAttribute"/>.</typeparam>
        /// <param name="property">The model property to validate.</param>
        /// <param name="isValid">refers to the result of validation of the previous properties.</param>
        /// <param name="failureMessages">The failure messages.</param>
        /// <returns>True if the Property is valid, false otherwise.</returns>
        private bool validateRequirement<VA>(PropertyInfo property, ref bool isValid, List<string> failureMessages) where VA : ValidationAttribute
        {
            if (Attribute.IsDefined(property, typeof(VA)))
            {
                var validationAttributes = Attribute.GetCustomAttributes(property, typeof(VA)) as VA[];
                foreach (var validationAttribute in validationAttributes)
                {
                    if (!validationAttribute.Validate(property.GetValue(this)))
                    {
                        isValid = false;
                        failureMessages.Add(validationAttribute.FailureMessage);
                        return false;
                    }
                }

            }
            return true;
        }
        #endregion
    }
}
