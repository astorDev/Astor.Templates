using Astor.Template.Protocol;
using Astor.Template.Protocol.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Astor.Template.WebApi.Controllers;

[Route(Uris.About)]
public class AboutController
{
    public IWebHostEnvironment Environment { get; }

    public AboutController(IWebHostEnvironment environment)
    {
        this.Environment = environment;
    }

    [HttpGet]
    public About Get()
    {
        return new About
        {
            Description = "Astor.Template - template API",
            Environment = this.Environment.EnvironmentName,
            Version = this.GetType().Assembly.GetName().Version!.ToString()
        };
    }
}