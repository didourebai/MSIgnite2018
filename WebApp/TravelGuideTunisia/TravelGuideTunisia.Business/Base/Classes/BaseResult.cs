using System.Collections.Generic;

namespace TravelGuideTunisia.Business.Base.Classes
{
    public class BaseResult
    {
        #region Properties
        public List<ErrorBase> Errors { get; set; }

        public string Status { get; set; }
        public string StatusDetail { get; set; }
        #endregion

        #region Constructors
        public BaseResult()
        {
            Errors = new List<ErrorBase>();
        }
        #endregion
    }
}
