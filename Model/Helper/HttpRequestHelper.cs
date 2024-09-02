using System.Dynamic;
using System.Net;

namespace HttpParser
{
    public class HttpRequestHelper
    {
        public enum ContentType
        {
            xml,
            json
        }

        public enum Method
        {
            POST,
            GET
        }

        public static string GetData(string requestUriString, ContentType contentType, Method method)
        {
            //1. HTTP 요청
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.ContentType = "application/" + contentType.ToString();
            request.Method = method.ToString();

            //POST 요청에만 사용 가능
            if (method == Method.POST)
            {
                var streamWriter = new StreamWriter(request.GetRequestStream());
                streamWriter.Write("");
                streamWriter.Flush();
                streamWriter.Close();
            }

            //2. Response 확인
            var httpResponse = (HttpWebResponse)request.GetResponse();
            var streamReader = new StreamReader(httpResponse.GetResponseStream());
            return streamReader.ReadToEnd();
        }
    }
}