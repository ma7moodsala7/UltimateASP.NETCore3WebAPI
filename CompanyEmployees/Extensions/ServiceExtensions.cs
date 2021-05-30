using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEmployees.Extensions
{


    /// <summary>
    /// An extension method is inherently a static method. What makes it different from other static methods is that
    /// it accepts 'this' as the first parameter, and 'this' represents the data type of the object which will be using that extension method.
    /// This kind of method extends the behavior of a type in .NET.
    /// </summary>
    public static class ServiceExtensions
    {


        /// <summary>
        /// CORS (Cross-Origin Resource Sharing) is a mechanism to give or restrict access rights to applications from different domains.
        /// If we want to send requests from a different domain to our application, configuring CORS is mandatory.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                        builder.AllowAnyOrigin() // allows all requests from all origins to be sent to our API
                            // builder.WithOrigins("http://localhost:4200") to allow specific origins.
                            .AllowAnyMethod() // or .WithMethods("POST", "GET")
                            .AllowAnyHeader() // or .WithHeaders("accept", "content-type")
                    // .AllowCredentials()
                );
            });
        }



        /// <summary>
        /// ASP.NET Core applications are by default self hosted, and if we want to host our application on IIS,
        /// we need to configure an IIS integration which will eventually help us with the deployment to IIS.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }




    }
}
