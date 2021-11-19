using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BusBoard
{
    public class TflResponse
    {
        ApiHandler apiHandler = new ApiHandler("https://api.tfl.gov.uk");
        public string ResponseString;
        public List<TflIndividual> ResponseList = new List<TflIndividual>();

        public void TflGetResponse(string stopId)
        {
            ResponseString = apiHandler.GetTflString($"StopPoint/{stopId}/Arrivals");
        }

        public void GenerateList()
        {
            ResponseList = JsonConvert.DeserializeObject<List<TflIndividual>>(ResponseString);
        }
    }
}