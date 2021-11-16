using Astor.Template.Protocol;
using Astor.Template.WebApi;

namespace Astor.Template.Tests;

public class WebApplicationFactory : UpdatedWebApplicationFactory<Startup>
{
    public TemplateClient Create()
    {
        this.EnsureHttpClientCreated();
        return new TemplateClient(this.HttpClient);
    }
}