using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusBoard.Api.Models
{
    public class TflIndividual
    {
        [JsonProperty("stationName")] public string StationName;
        [JsonProperty("lineId")] public string Route;
        [JsonProperty("destinationName")] public string DestinationName;
        [JsonProperty("expectedArrival")] public DateTime ExpectedArrival;
    }

    public class TflStopRes
    {
        [JsonProperty("stopPoints")] public List<TflStopPoint> StopPoints;
    }

    public class TflStopPoint
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("distance")] public float Distance;
        [JsonProperty("commonName")] public string Name;
        [JsonProperty("indicator")] public string Indicator;
    }
    
}