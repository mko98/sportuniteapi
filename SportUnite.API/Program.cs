﻿using System.IO;
using Microsoft.AspNetCore.Hosting;
using SportUnite.BLL;

namespace SportUnite.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://*:27017")
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}