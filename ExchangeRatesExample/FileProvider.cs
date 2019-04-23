using System.IO;
using System.Reflection;

namespace ExchangeRatesExample
{
    public class FileProvider : IContentProvider
    {
        private const string InputXmlPath = "..\\ExchangeRates\\InputXmlData\\ExchangeRates.xml";

        public string GetContent()
        {
            string filePath = InputXmlPath;
            filePath = GetRelativeFilePath(filePath);
            return File.ReadAllText(filePath);
        }

        private string GetRelativeFilePath(string filePath)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            return Path.Combine(outPutDirectory, filePath);
        }
    }
}