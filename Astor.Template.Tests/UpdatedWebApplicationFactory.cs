using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Astor.Template.Tests
{
    public class UpdatedWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected HttpClient httpClient;
        protected void ensureHttpClientCreated()
        {
            if (this.httpClient == null)
            {
                this.httpClient = this.CreateClient();
            }
        }
        
        public IServiceProvider ServiceProvider
        {
            get
            {
                this.ensureHttpClientCreated();
                return this.Server.Host.Services;
            }
        }
    }
}