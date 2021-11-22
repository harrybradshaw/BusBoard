using BusBoard.Api;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var loc = new Location("Nw6 1EH");
            loc.GetStops();
        }
    }
}