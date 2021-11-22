using BusBoard.Api;
using BusBoard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusBoard.Web.Controllers
{
    public class BusesController : Controller
    {
        // GET
        [HttpGet("buses/arrivals")]
        public IActionResult Arrivals([FromQuery] string postcode)
        {
            var location = new Location();
            location.SetPostcode(postcode);
            location.GetLatLon();
            if (location.IsValid())
            {
                location.GetStops();
            }
            return View(location);
        }
    }
}