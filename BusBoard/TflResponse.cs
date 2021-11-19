using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BusBoard
{
    public class TflResponse
    {
        ApiHandler apiHandler = new ApiHandler("https://api.tfl.gov.uk");
        public string ResponseStringArrival;
        public string ResponseStringStopCode;
        public List<TflIndividual> ResponseList = new List<TflIndividual>();
        public TflStopRes StopRes = new TflStopRes();

        public void TflGetResponse(string stopId)
        {
            ResponseStringArrival = apiHandler.GetString($"StopPoint/{stopId}/Arrivals");
        }

        public void TflGetStopCode(string lat, string lon)
        {
            ResponseStringStopCode =
                apiHandler.GetString($"StopPoint/?lat={lat}&lon={lon}&stopTypes=NaptanPublicBusCoachTram&radius=1000");
        }

        public void GenerateList()
        {
            ResponseList = JsonConvert.DeserializeObject<List<TflIndividual>>(ResponseStringArrival);
        }

        public void ParseStopCodeString()
        {
            StopRes = JsonConvert.DeserializeObject<TflStopRes>(ResponseStringStopCode);
        }
        
    }
}