using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ExchangeRatesExample.Utility.XmlParser;

namespace ExchangeRatesExample
{
    public class ExchangeRateLogic : IExchangeRateLogic
    {
        private const string InputXmlPath = "..\\ExchangeRates\\InputXmlData\\ExchangeRates.xml";

        private const string UsdSwiftCode = "USD";

        private const string EurSwiftCode = "EUR";

        private readonly IXmlParser<web_dis_rates> _xmlParser;

        public ExchangeRateLogic(IXmlParser<web_dis_rates> xmlParser)
        {
            _xmlParser = xmlParser;
        }

        public List<ExchangeRateViewModel> GetUsdAndEurExchangeRates()
        {
            var rawData = GetRawExchangeRatesData();
            return rawData.row.Where(x => x.swift_code == UsdSwiftCode || x.swift_code == EurSwiftCode).Select(x => new ExchangeRateViewModel
                {Name = x.swift_name, Value = x.CurrencyGuide.Value}).ToList();
        }

        public web_dis_rates GetRawExchangeRatesData()
        {
            XDocument doc = _xmlParser.ReadXmlData(InputXmlPath);
            web_dis_rates exchangeRateData = _xmlParser.MapToModel(doc);
            return exchangeRateData;
        }
    }
}