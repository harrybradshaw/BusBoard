using System.Collections.Generic;
using BusBoard.Api.Models;

namespace BusBoard.Api
{
    public class Location
    {
        public string Postcode;
        private string _lat;
        private string _lon;
        private bool _isValid = false;
        //public TflStopRes tflStopResp = new TflStopRes();
        public List<Stop> Stops = new List<Stop>();

        public void SetPostcode(string postcode)
        {
            Postcode = postcode;
        }

        public void GetLatLon()
        { 
            PostcodeResponse postcodeResponse = new PostcodeResponse();
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
            TflApi tflApi = new TflApi();
            tflApi.GetStopCode(_lat,_lon);
            foreach (var stopPoint in tflApi.StopRes.StopPoints)
            {
                Stops.Add(new Stop(stopPoint.Id));
            }

            foreach (var stop in Stops)
            {
                stop.GetArrivals();
            }
        }

        public bool IsValid()
        {
            return _isValid;
        }
        
        
    }
}