using System;
using Microsoft.Owin.Hosting;
using ODataTest;

namespace ODataSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9003/"))
            {
                Console.ReadLine();
            }
        }
    }
}
