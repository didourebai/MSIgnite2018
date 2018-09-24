using System.Collections.Generic;
using System.IO;
using System.Net;
using TravelGuideTunisia.Business.Base.Classes;

namespace TravelGuideTunisia.Business.Helpers
{
    public static class HttpPostman
    {
        public static PostmanSendResponse Send(HttpRequestProperties properties)
        {
            var uri = AddAttributesToUri(properties.Uri, properties.UriAttributesToSend);

            var httpRequest = (HttpWebRequest)WebRequest.Create(uri);

            httpRequest.Method = properties.Method;
            httpRequest.ContentType = properties.ContentType;
            httpRequest.MaximumAutomaticRedirections = properties.MaximumAutomaticRedirections;
            httpRequest.AllowAutoRedirect = properties.AllowAutoRedirect;

            if (!string.IsNullOrWhiteSpace(properties.JsonDataToSend))
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(properties.JsonDataToSend);
                    streamWriter.Flush();
                }
            }

            HttpWebResponse httpResponse = null;

            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException httpErrorResult)
            {
                httpResponse = (HttpWebResponse)httpErrorResult.Response;
            }

            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return new PostmanSendResponse
                {
                    ResponseData = reader.ReadToEnd(),
                    Status = httpResponse.StatusCode,
                };
            }
        }

        private static string AddAttributesToUri(string uri, Dictionary<string, string> attributes)
        {
            if (attributes == null || attributes.Count < 1)
                return uri;

            uri = uri + "?";

            foreach (var atr in attributes)
                uri = uri + atr.Key + "=" + atr.Value + "&";

            return uri.TrimEnd('&');
        }
    }
}
