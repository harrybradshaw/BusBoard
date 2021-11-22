using BusBoard.Api.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusBoard.Api
{
    public class Stop
    {
        public string StopCode;
        public List<TflIndividual> ArrivalsList;

        public Stop(string stopCode)
        {
            StopCode = stopCode;
        }
        
        public void GetArrivals()
        {
            ApiHandler apiHandler = new ApiHandler("https://api.tfl.gov.uk");
            string responseStringArrival = apiHandler.GetString($"StopPoint/{StopCode}/Arrivals");
            ArrivalsList = JsonConvert.DeserializeObject<List<TflIndividual>>(responseStringArrival);
            if (ArrivalsList.Count > 1)
            {
                ArrivalsList.Sort((x, y) => x.ExpectedArrival.CompareTo(y.ExpectedArrival));
            }
            
        }
    }
}