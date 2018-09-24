using System;

namespace TravelGuideTunisia.Business.Base.Classes
{
    public class InternalError : ErrorBase
    {
        #region Properties
        public Exception Exception { get; set; }
        #endregion
    }
}
