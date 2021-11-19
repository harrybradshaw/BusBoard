using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusBoard
{
    public class PostcodeResponse
    {
        ApiHandler apiHandler = new ApiHandler("https://api.postcodes.io");
        public string ResponseString;
        public PostcodeIndividual PostcodeInd;

        public void PostcodesGetResponse(string postcode)
        {
            ResponseString = apiHandler.GetString($"postcodes/{postcode}");
        }

        public void ConvertString()
        {
            PostcodeInd = JsonConvert.DeserializeObject<PostcodeIndividual>(ResponseString);
        }
        
        
    }
}