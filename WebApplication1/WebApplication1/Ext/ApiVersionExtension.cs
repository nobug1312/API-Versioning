using Asp.Versioning;

namespace WebApplication1.Ext
{
    public static class ApiVersionExtension
    {
        //DefaultApiVersion - Sets the default API version. Typically, this will be v1.0.
        //ReportApiVersions - Reports the supported API versions in the api-supported-versions response header.
        //AssumeDefaultVersionWhenUnspecified - Uses the DefaultApiVersion when the client didn't provide an explicit version.
        //ApiVersionReader - Configures how to read the API version specified by the client. The default value is QueryStringApiVersionReader.
        public static IServiceCollection AddApiVersionService(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(2, 1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                        new UrlSegmentApiVersionReader(),
                        new QueryStringApiVersionReader("api-version"),
                        new HeaderApiVersionReader("X-Api-Version"));
            })
                .AddMvc() // This is needed for controllers
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });
            return services;
        }
    }
}
