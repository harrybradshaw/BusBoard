using RestSharp;

namespace BusBoard.Api
{
    public class ApiHandler
    {
        public string BaseUrl;
        private IRestClient _client;

        public ApiHandler(string baseUrl = "")
        {
            BaseUrl = baseUrl;
            _client = new RestClient(baseUrl);
        }
        
        public string GetString(string requestString)
        {
            RestRequest request = new RestRequest(requestString);
            return _client.Get(request).Content;
        }

    }
}
