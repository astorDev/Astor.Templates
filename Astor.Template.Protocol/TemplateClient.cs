using System.Net.Http;
using System.Threading.Tasks;
using Astor.Template.Protocol.Models;

namespace Astor.Template.Protocol;

public class TemplateClient : RestApiClient
{
    public TemplateClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<About> GetAboutAsync()
    {
        var response = await this.HttpClient.GetAsync(Uris.About);
        return await this.ReadAsync<About>(response);
    }
}
