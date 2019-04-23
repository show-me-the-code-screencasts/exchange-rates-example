using System.Collections.Generic;

namespace ExchangeRatesExample
{
    public interface IExchangeRateLogic
    {
        List<ExchangeRateViewModel> GetUsdAndEurExchangeRates();
        web_dis_rates GetRawExchangeRatesData();
    }
}