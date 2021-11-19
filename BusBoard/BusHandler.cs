using System;

namespace BusBoard
{
    public class BusHandler
    {
        private TflResponse buses = new TflResponse();
        
        public void GenerateBuses()
        {
            buses.TflGetResponse();
            buses.GenerateList();
        }

        public void PrintBuses()
        {
            GenerateBuses();
            buses.ResponseList.Sort((x, y) => x.ExpectedArrival.CompareTo(y.ExpectedArrival));
            for (int i = 0; i<5; i++)
            {
                Console.WriteLine($"{buses.ResponseList[i].Route} to {buses.ResponseList[i].DestinationName}: Arriving in {(buses.ResponseList[i].ExpectedArrival - DateTime.Now).Minutes} Mins");
            }
        }
        
    }
}