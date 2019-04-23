using System.Xml.Linq;

namespace ExchangeRatesExample.Utility.XmlParser
{
    public interface IXmlParser<T>
    {
        XDocument ReadXmlData(string filePath);
        T MapToModel(XDocument doc);
    }
}