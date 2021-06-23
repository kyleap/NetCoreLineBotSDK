using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models;
using NetCoreLineBotSDK.Utility;
using System.Text.Json.Serialization;

namespace NetCoreLineBotSDK
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLineBotSDK(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
            });

            services.Configure<LineSetting>(option => configuration.GetSection("LineSetting").Bind(option));
            services.AddHttpClient<ILineMessageUtility, LineMessageUtility>();
            return services;
        }
    }
}
