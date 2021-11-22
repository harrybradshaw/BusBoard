using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace BusBoard.Api.Models
{
    public class PostcodeIndividual
    {
        [JsonProperty("result")] public PostcodeResult Pstres;
    }

    public class PostcodeResult
    {
        [JsonProperty("longitude")] public string Lon;
        [JsonProperty("latitude")] public string Lat;
    }
}