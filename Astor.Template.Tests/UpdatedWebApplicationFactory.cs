using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Astor.Template.Tests;

public class UpdatedWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
    protected HttpClient HttpClient;
    protected void EnsureHttpClientCreated()
    {
        this.HttpClient ??= this.CreateClient();
    }
        
    public IServiceProvider ServiceProvider
    {
        get
        {
            this.EnsureHttpClientCreated();
            return this.Server.Host.Services;
        }
    }
}