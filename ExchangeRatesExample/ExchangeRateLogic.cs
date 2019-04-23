using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ExchangeRatesExample
{
    public class ExchangeRateLogic : IExchangeRateLogic
    {
        private const string InputXmlPath = "..\\ExchangeRates\\InputXmlData\\ExchangeRates.xml";

        private const string UsdSwiftCode = "USD";

        private const string EurSwiftCode = "EUR";
        

        public List<ExchangeRateViewModel> GetUsdAndEurExchangeRates()
        {
            var rawData = GetRawExchangeRatesData();
            return rawData.row.Where(x => x.swift_code == UsdSwiftCode || x.swift_code == EurSwiftCode).Select(x => new ExchangeRateViewModel
                {Name = x.swift_name, Value = x.CurrencyGuide.Value}).ToList();
        }

        public web_dis_rates GetRawExchangeRatesData()
        {
            XDocument doc = ReadXmlData(InputXmlPath);
            web_dis_rates exchangeRateData = MapToModel(doc);
            return exchangeRateData;
        }

        public XDocument ReadXmlData(string filePath)
        {
            filePath = GetRelativeFilePath(filePath);
            XDocument doc = XDocument.Load(filePath);

            return doc;
        }

        public web_dis_rates MapToModel(XDocument doc)
        {
            XmlSerializer s = new XmlSerializer(typeof(web_dis_rates));
            return (web_dis_rates)s.Deserialize(doc.CreateReader());
        }

        private string GetRelativeFilePath(string filePath)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            return Path.Combine(outPutDirectory, filePath);
        }
    }
}