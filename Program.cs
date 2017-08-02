using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace asp_ng
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
             //   .UseSetting("detailedErrors","true") // dev only
                .UseIISIntegration()
                .UseStartup<Startup>()
              //  .CaptureStartupErrors(true) //dev only
                .Build();

            host.Run();
        }
    }
}
