using System.Collections.Generic;
using BusBoard.Api.Models;
using Newtonsoft.Json;

namespace BusBoard.Api
{
    public class TflApi
    {
        private readonly ApiHandler _apiHandler = new ApiHandler("https://api.tfl.gov.uk");
        public List<TflIndividual> ResponseList;
        public TflStopRes StopRes = new ();

        public void GetArrivals(string stopId)
        {
            var responseStringArrival = _apiHandler.GetString($"StopPoint/{stopId}/Arrivals");
            ResponseList = JsonConvert.DeserializeObject<List<TflIndividual>>(responseStringArrival);
        }

        public void GetStopCode(string lat, string lon)
        {
            var responseStringStopCode =
                _apiHandler.GetString($"StopPoint/?lat={lat}&lon={lon}&stopTypes=NaptanPublicBusCoachTram");
            StopRes = JsonConvert.DeserializeObject<TflStopRes>(responseStringStopCode);
        }
    }
}