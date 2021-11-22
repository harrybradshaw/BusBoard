using BusBoard.Api.Models;
using Newtonsoft.Json;

namespace BusBoard.Api
{
    public class PostcodeResponse
    {
        private ApiHandler apiHandler = new ApiHandler("https://api.postcodes.io");
        public PostcodeIndividual PostcodeInd;
        private string _postcode;

        public void PostcodesGetResponse(string postcode)
        {
            _postcode = postcode;
            string responseString = apiHandler.GetString($"postcodes/{postcode}");
            PostcodeInd = JsonConvert.DeserializeObject<PostcodeIndividual>(responseString);
        }
        
    }
}