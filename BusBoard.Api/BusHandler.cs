using System;

namespace BusBoard.Api
{
    public class BusHandler
    {
        private TflApi buses = new TflApi();
        private string _stopCode;

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
            
            buses.GetArrivals(_stopCode);
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

        public void FindNearestTwo(string postcode = "")
        {
            if (postcode == "")
            {
                Console.WriteLine("Please enter a postcode!");
                string tempString = Console.ReadLine();
                //postcode = new string (tempString.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                postcode = tempString;
            }
            var postcodeRes = new PostcodeResponse();
            postcodeRes.PostcodesGetResponse(postcode);
            buses.GetStopCode(postcodeRes.PostcodeInd.Pstres.Lat,postcodeRes.PostcodeInd.Pstres.Lon);
            if (buses.StopRes.StopPoints.Count >= 2)
            {
                PrintSingle(buses.StopRes.StopPoints[0].Id, buses.StopRes.StopPoints[0].Distance);
                PrintSingle(buses.StopRes.StopPoints[1].Id, buses.StopRes.StopPoints[1].Distance);
            }
            else
            {
                Console.WriteLine("The postcode provided was out of range/invalid.");
            }
            
        }
        
    }
}