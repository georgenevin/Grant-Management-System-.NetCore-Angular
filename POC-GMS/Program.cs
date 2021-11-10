using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace POC_GMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger();
            Log.Information("Application Started");
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Error(ex, "The application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
     
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(@"log.txt").CreateLogger();
        }
    }
}
