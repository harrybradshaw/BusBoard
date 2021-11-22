using BusBoard.Api;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Location loc = new Location();
            loc.SetPostcode("Nw4 2hf");
            loc.GetStops();
        }
    }
}