using TravelGuideTunisia.Business.Base.Classes;
using Newtonsoft.Json;

namespace TravelGuideTunisia.Business.Helpers
{
    public static class JsonTranslator
    {
        /// <summary>
        /// De-serializes any type of responses from Koda or Ksso
        /// </summary>
        /// <typeparam name="T">The type of the data</typeparam>
        /// <param name="jsonStringResponse">The Json string of the response</param>
        /// <returns></returns>
        public static ResponseEnvelope<T> DeserializeResult<T>(string jsonStringResponse) where T : class
        {
            var deserializedResult = JsonConvert.DeserializeObject<ResultEnvelope<T>>(jsonStringResponse);
            var deserializedResponse = deserializedResult == null || deserializedResult.Result == null
                ? JsonConvert.DeserializeObject<ResponseEnvelope<T>>(jsonStringResponse)
                : deserializedResult.Result;
            return deserializedResponse;
        }
    }
}
