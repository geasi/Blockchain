using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blockchain.Hub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var arguments = new Arguments(args.ToList());

            if (arguments?.Loaded ?? false)
            {
                foreach (var address in arguments.Addresses ?? new string[0])
                {
                    NodeHub.ConnectToNode(address);
                }

                return WebHost.CreateDefaultBuilder(args)
                    // .ConfigureServices((IServiceCollection services) =>
                    // {
                    //     var nodeHub = new NodeHub(arguments);
                    //     services.AddSingleton<NodeHub>(nodeHub);
                    //     services.AddSingleton<Chain>(nodeHub.Blockchain);
                    // })
                    .UseStartup<Startup>()
                    .UseUrls($"http://localhost:{arguments.Port}");
            }

            throw new ArgumentException();
        }
    }
}
