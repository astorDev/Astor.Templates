global using Astor.Template.Protocol;
global using Astor.Template.Tests.Core;
global using System.Threading.Tasks;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using System;
global using System.Net.Http;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Astor.Template.WebApi;

namespace Astor.Template.Tests.Core;

public class Test
{
    public readonly WebApplicationFactory Factory = new();

    public TemplateClient Client => this.Factory.Create();
}