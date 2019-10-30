using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace SerilogLog
{
    class Program
    {
        static void Main(string[] args)
        {
            //var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            //log.Information("Hello,零度");

            //Log.Logger = log;
            //Log.Information("The global logger has been configured");

            //Console.ReadLine();

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello,world");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Divding {A} by {B}", a, b);
                Console.WriteLine(a / b);
                
            }
            catch (Exception)
            {
                Log.Error("something went wrong");
            }

            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}
