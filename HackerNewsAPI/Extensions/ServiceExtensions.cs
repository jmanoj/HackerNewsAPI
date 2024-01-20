using HackerNewsAPI.Model;
using HackerNewsAPI.Services;

namespace HackerNewsAPI.Extensions;

public static class ServiceExtensions
{
	public static void ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHttpClient();
		services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
        services.AddScoped<IHackerNewsService, HackerNewsService>();
	}

    public static void ConfigureCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(policyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }
    
}
