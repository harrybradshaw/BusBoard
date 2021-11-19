using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class ApiHandler
    {
        public string BaseUrl;
        public IRestClient client;
        

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
        
        
        public string GetTflString(string requestString)
        {
            RestRequest request = new RestRequest(requestString);
            return ExecuteString<List<TflIndividual>>(request);
        }
        
        public string GetString(string requestString)
        {
            RestRequest request = new RestRequest(requestString);
            return client.Get(request).Content;
        }

        public string ExecuteString<T>(RestRequest request) where T : new()
        {
            var response = client.Execute<T>(request);
            return response.Content;
        }

    }
}
