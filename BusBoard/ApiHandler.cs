using RestSharp;

namespace BusBoard
{
    public class ApiHandler
    {
        private string BaseUrl;
        private IRestClient client;

        public ApiHandler(string baseUrl = "")
        {
            BaseUrl = baseUrl;
            client = new RestClient(baseUrl);
        }

        public void SetBaseUrl(string baseUrl)
        {
            BaseUrl = baseUrl;
            client = new RestClient(baseUrl);
        }

        public TflResponse GetTflResponse(string requestString)
        {
            RestRequest request = new RestRequest(requestString,DataFormat.Json);
            return Execute<TflResponse>(request);
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = client.Execute<T>(request);
            return response.Data;
        }
        
    }
}
