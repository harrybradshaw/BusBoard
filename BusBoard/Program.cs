namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            BusHandler busHandler = new BusHandler();
            //busHandler.PrintSingle("490008660N");
            busHandler.Part2("NW61EH");
        }
    }
}