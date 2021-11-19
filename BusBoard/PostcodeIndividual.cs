using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace BusBoard
{
    public class PostcodeIndividual
    {
        [JsonProperty("result")] public PostcodeResult pstres;
    }

    public class PostcodeResult
    {
        [JsonProperty("longitude")] public string lon;
        [JsonProperty("latitude")] public string lat;
    }
}