using ExchangeRatesExample.Utility;

namespace ExchangeRatesExample
{
    public class ExchangeRatesRetriever
    {
        private readonly IContentProvider _contentProvider;

        public ExchangeRatesRetriever(IContentProvider contentProvider)
        {
            _contentProvider = contentProvider;
        }

        public web_dis_rates GetRawExchangeRates()
        {
            string content = _contentProvider.GetContent();

            return XmlParser.XmlDeserializeFromString<web_dis_rates>(content);
        }
    }
}