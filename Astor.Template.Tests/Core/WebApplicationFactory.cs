namespace Astor.Template.Tests.Core;

public class WebApplicationFactory : UpdatedWebApplicationFactory<Startup>
{
    public TemplateClient Create()
    {
        this.EnsureHttpClientCreated();
        return new(this.HttpClient!);
    }
}