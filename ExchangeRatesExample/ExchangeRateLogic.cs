using System.Collections.Generic;
using System.Linq;

namespace ExchangeRatesExample
{
    public class ExchangeRateLogic
    {
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
            var fileProvider = new FileProvider();
            var exchangeRatesRetriever = new ExchangeRatesRetriever(fileProvider);

            return exchangeRatesRetriever.GetRawExchangeRates();
        }
    }
}