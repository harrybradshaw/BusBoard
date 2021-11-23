using BusBoard.Api;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var loc = new Location("NW6 1EH");
            loc.GetStops();
        }
    }
}