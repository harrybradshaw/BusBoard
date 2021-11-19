using System;
using Newtonsoft.Json;

namespace BusBoard
{
    public class TflIndividual
    {
        [JsonProperty("stationName")] public string StationName;
        [JsonProperty("lineId")] public string Route;
        [JsonProperty("destinationName")] public string DestinationName;
        [JsonProperty("expectedArrival")] public DateTime ExpectedArrival;
    }
}