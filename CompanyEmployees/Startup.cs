using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompanyEmployees
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        /// A Service is a reusable part of the code that adds some functionality to our application.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors(); 
            services.ConfigureIISIntegration();


            // instead of AddMvc() as used in 2.2, now we have AddControllers().
            // This method registers only the controllers in IServiceCollection and not Views or Pages because they are not required in the Web API project.
            services.AddControllers();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// Add different middleware components to the application's request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //} 

            app.UseHttpsRedirection();

            // enables using static files for the request.
            // If we don’t set a path to the static files directory, it will use a wwwroot folder in our project by default.
            app.UseStaticFiles(); 
            
            app.UseCors("CorsPolicy");


            // will forward proxy headers to the current request. This will help us during application deployment. // TODO: try to understand this middleware component.
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
