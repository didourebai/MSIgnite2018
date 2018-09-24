using TravelGuideTunisia.Business.Validation;

namespace TravelGuideTunisia.Business.Models.EventRegistration
{
    public class PostEventRegistrationResultModel : SelfValidationModel
    {
        [Mandatory(FailureMessage = "[Event Registration] -Error in the [UserName] field - Mandatory field")]
        public string UserName { get; set; }

        [Mandatory(FailureMessage = "[Event Registration] -Error in the [EventTitle] field - Mandatory field")]
        public string EventTitle { get; set; }
    }
}
