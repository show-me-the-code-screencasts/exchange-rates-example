using System.Collections.Generic;
using System.Xml.Linq;

namespace ExchangeRatesExample
{
    public interface IExchangeRateLogic
    {
        List<ExchangeRateViewModel> GetUsdAndEurExchangeRates();
        web_dis_rates GetRawExchangeRatesData();
        XDocument ReadXmlData(string filePath);
        web_dis_rates MapToModel(XDocument doc);
    }
}