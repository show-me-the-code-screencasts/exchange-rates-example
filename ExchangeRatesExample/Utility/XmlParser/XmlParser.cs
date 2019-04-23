using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ExchangeRatesExample.Utility.XmlParser
{
    public class XmlParser<T> : IXmlParser<T>
    {
        public XDocument ReadXmlData(string filePath)
        {
            filePath = GetRelativeFilePath(filePath);
            XDocument doc = XDocument.Load(filePath);

            return doc;
        }

        public T MapToModel(XDocument doc)
        {
            XmlSerializer s = new XmlSerializer(typeof(web_dis_rates));
            return (T)s.Deserialize(doc.CreateReader());
        }

        private string GetRelativeFilePath(string filePath)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            return Path.Combine(outPutDirectory, filePath);
        }
    }
}