using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            BusHandler busHandler = new BusHandler();
            busHandler.PrintBuses();
        }
    }
}