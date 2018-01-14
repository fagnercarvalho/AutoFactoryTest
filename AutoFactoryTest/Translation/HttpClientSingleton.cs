using System.Net.Http;

namespace AutoFactoryTest.Translation
{
    public class HttpClientSingleton
    {
        private static HttpClientSingleton instance { get; set; }
        private static HttpClient httpClient { get; set; }

        private HttpClientSingleton()
        {

        }

        public static HttpClientSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpClientSingleton();
                }

                return instance;
            }
        }

        public HttpClient GetHttpClient()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            return httpClient;
        }
    }
}
