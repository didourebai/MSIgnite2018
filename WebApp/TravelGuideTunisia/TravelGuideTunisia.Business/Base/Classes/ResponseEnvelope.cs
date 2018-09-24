using System.Collections.Generic;
using Newtonsoft.Json;
using RH.Standards.Domain;

namespace TravelGuideTunisia.Business.Base.Classes
{
    public class ResponseEnvelope<T> : ResultOfType<T>
    {
        [JsonProperty("data")]
        public override T Data { get; set; }

        [JsonProperty("errors")]
        public override List<RH.Standards.Domain.IAmError> Errors { get; set; }

        [JsonProperty("statusDetail")]
        public new EStatusDetail StatusDetail 
        { 
            get { return base.StatusDetail; } 
            set { base.StatusDetail = value; } 
        }

        [JsonProperty("status")]
        public new EResultStatus Status 
        { 
            get { return base.Status; } 
            set { base.Status = value; } 
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
