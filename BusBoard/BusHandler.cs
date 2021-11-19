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

        public void PrintSingle(string stopCode = "")
        {
            if (stopCode is not null)
            {
                SetStopCode(stopCode);
            }
            
            GenerateBuses();
            buses.ResponseList.Sort((x, y) => x.ExpectedArrival.CompareTo(y.ExpectedArrival));
            for (int i = 0; i< Math.Min(5,buses.ResponseList.Count); i++)
            {
                Console.WriteLine($"{buses.ResponseList[i].Route} to {buses.ResponseList[i].DestinationName}: Arriving in {(buses.ResponseList[i].ExpectedArrival - DateTime.Now).Minutes} Mins");
            }
        }
        
    }
}