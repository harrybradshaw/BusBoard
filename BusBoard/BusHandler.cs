using System;

namespace BusBoard
{
    public class BusHandler
    {
        private TflResponse buses = new TflResponse();
        private string _stopCode;
        public void GenerateBuses()
        {
            buses.TflGetResponse(_stopCode);
            buses.GenerateList();
        }

        public void SetStopCode(string stopCode)
        {
            _stopCode = stopCode;
        }

        public void PrintSingle(string stopCode = "", float distance = 0)
        {

            if (stopCode is not null)
            {
                SetStopCode(stopCode);
            }
            
            GenerateBuses();
            if (distance != 0)
            {
                Console.WriteLine($"{buses.ResponseList[0].StationName} ({distance}m away)");
            }
            else
            {
                Console.WriteLine(buses.ResponseList[0].StationName);
            }
            
            buses.ResponseList.Sort((x, y) => x.ExpectedArrival.CompareTo(y.ExpectedArrival));
            for (int i = 0; i< Math.Min(5,buses.ResponseList.Count); i++)
            {
                Console.WriteLine($"{buses.ResponseList[i].Route} to {buses.ResponseList[i].DestinationName}: Arriving in {(buses.ResponseList[i].ExpectedArrival - DateTime.Now).Minutes} Mins");
            }
        }

        public void Part2(string postcode)
        {
            PostcodeResponse postcodeRes = new PostcodeResponse();
            postcodeRes.PostcodesGetResponse(postcode);
            postcodeRes.ConvertString();
            string lat = postcodeRes.PostcodeInd.pstres.lat;
            string lon = postcodeRes.PostcodeInd.pstres.lon;
            buses.TflGetStopCode(lat,lon);
            buses.ParseStopCodeString();
            PrintSingle(buses.StopRes.StopPoints[0].Id, buses.StopRes.StopPoints[0].Distance);
            PrintSingle(buses.StopRes.StopPoints[1].Id, buses.StopRes.StopPoints[1].Distance);
        }
        
    }
}