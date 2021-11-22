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
            var location = new Location(postcode);
            location.GetLatLon();
            if (location.IsValid())
            {
                Response.Headers.Add("Refresh","10");
                location.GetStops();
            }
            return View(location);
        }
    }
}