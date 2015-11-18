using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace iLoan.API
{
    class Program
    {
        static void Main(string[] args)
        {
            StartOptions options = new StartOptions("http://localhost:8080/");
            options.Urls.Add("http://127.0.0.1:8080/");
            options.Urls.Add(string.Format("http://{0}:8080", Environment.MachineName));
            options.Urls.Add("http://*:8080/");
            options.Port = 8080;

            // Start OWIN host 
            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine("Server running at port " +options.Port);
                Console.ReadLine();
            }

            
        }
    }
}
