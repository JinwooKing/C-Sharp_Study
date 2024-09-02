using HttpParser;
using System.Xml.Linq;
using static HttpParser.HttpRequestHelper;

namespace ConsoleAppSample.Study.Cls
{
    public class XmlDocumentCls
    {
        public XmlDocumentCls()
        {
            var xmldata = HttpRequestHelper.GetData(@"", ContentType.xml, Method.GET);
            XDocument doc = XDocument.Parse(xmldata);

            var upperDamValue = doc.Descendants("item")
                                   .Where(x => x.Element("expl").Value == "수위")
                                   .Select(x => x.Element("value").Value)
                                   .FirstOrDefault();
            Console.WriteLine("수위의 value 값: " + upperDamValue);
        }
    }
}
