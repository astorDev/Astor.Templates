using System;
using System.Net.Http;
using System.Threading.Tasks;
using Astor.Template.Protocol;
using Astor.Template.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Astor.Template.Tests
{
    public class WebApplicationFactory : WebApplicationFactory<Startup>
    {
        private HttpClient httpClient;
        private void ensureHttpClientCreated()
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
        
        public MyClient Create()
        {
            this.ensureHttpClientCreated();
            return new TestClient(this.httpClient);
        }
        
        private class TestClient : MyClient
        {
            public TestClient(HttpClient httpClient) : base(httpClient)
            {
            }

            protected override async Task OnResponseReceivedAsync(HttpResponseMessage response)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
        }
    }
}