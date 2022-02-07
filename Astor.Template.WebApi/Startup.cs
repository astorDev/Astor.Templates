namespace Astor.Template.WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson(json =>
            {
                json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new()
            {
                Title = "Astor.Template",
                Version = this.GetType().Assembly.GetName().Version!.ToString()
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Astor.Template");
        });

        app.UseRequestsLogging(l => l.IgnoredPathPatterns.Add("/swagger.*"));

        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                var error = Error.Interpret(exceptionHandlerPathFeature!.Error, true);

                context.Response.StatusCode = (int)error.Code;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(error, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                }));
            });
        });

        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
