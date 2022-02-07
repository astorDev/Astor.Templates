global using Astor.Logging;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Astor.Template.Protocol;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using System;
global using System.Collections;
global using System.Linq;
global using System.Threading.Tasks;
global using System.Net;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.OpenApi.Models;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Serialization;

namespace Astor.Template.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                JsonConsoleLoggerProviderExtensions.AddJsonConsole(logging);
            });
        
}