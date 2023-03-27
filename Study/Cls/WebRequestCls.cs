using System.Net;

namespace ConsoleAppSample.Study.Cls
{
    public class WebRequestCls
    {
        public WebRequestCls()
        { 
            //1. HTTP 요청
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(@"https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo=1");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            //POST 요청에만 사용 가능
            var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            streamWriter.Write("");
            streamWriter.Flush();
            streamWriter.Close();

            //2. Response 확인
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var result = streamReader.ReadToEnd();
            Console.WriteLine(result);
        }
    }
}
