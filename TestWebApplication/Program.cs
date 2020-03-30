using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // StartupTesting constructor is called once during test method call.
                    // Validators are called without any problem.
                    // webBuilder.UseStartup<Startup>();



                    // StartupTesting constructor is called twice during test method call.
                    // Also RegisterValidatorsFromAssemblyContaining causes request which use validators to fail.
                    webBuilder.UseStartup(typeof(Startup).Assembly.FullName);
                });
    }
}
