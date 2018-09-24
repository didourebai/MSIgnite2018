using TravelGuideTunisia.Business.Base.Interfaces;

namespace TravelGuideTunisia.Business.Base.Classes
{
    public class ErrorBase : IAmError
    {
        #region Properties
        public RH.Standards.Domain.EErrorType Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        #endregion
    }

}
