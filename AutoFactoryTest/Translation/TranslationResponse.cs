using Newtonsoft.Json;

namespace AutoFactoryTest.Translation
{
    class TranslationResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("text")]
        public string[] Text { get; set; }
    }
}
