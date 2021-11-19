using System;
using System.Runtime.CompilerServices;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiHandler apiHandler = new ApiHandler("https://api.tfl.gov.uk");
            TflResponse response = apiHandler.GetTflResponse("StopPoint/490008660N/Arrivals");
        }
    }
}