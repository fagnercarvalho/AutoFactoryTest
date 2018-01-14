using Newtonsoft.Json;
using System.Configuration;
using System.Threading.Tasks;

namespace AutoFactoryTest.Translation
{
    [TranslationLanguage("English")]
    internal class EnglishTranslation : ITranslation
    {
        private const string languageCode = "en";

        private const string translationBaseUrl = "https://translate.yandex.net/api/v1.5/tr.json/translate";

        private readonly string apiKey = ConfigurationManager.AppSettings["YandexApiKey"];

        public async Task<string> Translate(string text)
        {
            var queryString = string.Format("?key={0}&text={1}&lang={2}", apiKey, text, languageCode);

            var response = await HttpClientSingleton
                .Instance
                .GetHttpClient()
                .GetAsync(translationBaseUrl + queryString);

            if (!response.IsSuccessStatusCode)
            {
                return await Task.FromResult(string.Empty);
            }

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TranslationResponse>(data).Text[0];
        }
    }
}
