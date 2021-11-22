using System;
using System.Collections.Generic;

namespace BusBoard.Api
{
    public class Location
    {
        public string Postcode;
        private string _lat;
        private string _lon;
        private bool _isValid;
        public List<Stop> Stops = new ();
        
        public Location(string postcode)
        {
            Postcode = postcode;
        }

        public void GetLatLon()
        { 
            var postcodeResponse = new PostcodeResponse();
            postcodeResponse.PostcodesGetResponse(Postcode);
            if (postcodeResponse.PostcodeInd.Pstres is not null)
            {
                _isValid = true;
                _lat = postcodeResponse.PostcodeInd.Pstres.Lat;
                _lon = postcodeResponse.PostcodeInd.Pstres.Lon;
            }
        }

        public void GetStops()
        {
            if (_isValid)
            {
                var tflApi = new TflApi();
                tflApi.GetStopCode(_lat,_lon);
                foreach (var stopPoint in tflApi.StopRes.StopPoints)
                {
                    var tempStop = new Stop(stopPoint.Id, stopPoint.Name, stopPoint.Distance, stopPoint.Indicator);
                    tempStop.GetArrivals();
                    Stops.Add(tempStop);
                }
            }
            else
            {
                Console.WriteLine("Postcode is invalid!");
            }
        }

        public bool IsValid()
        {
            return _isValid;
        }
        
        
    }
}