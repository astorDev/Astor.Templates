using System;
using System.Net.Http;
using System.Threading.Tasks;
using Astor.Template.Protocol;
using Astor.Template.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Astor.Template.Tests
{
    public class WebApplicationFactory : UpdatedWebApplicationFactory<Startup>
    {
        public TemplateClient Create()
        {
            this.ensureHttpClientCreated();
            return new TemplateClient(this.httpClient);
        }
    }
}