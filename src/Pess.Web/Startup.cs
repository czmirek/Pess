namespace Pess.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Pess.Data;
    using Pess.Data.Xml;
    using Pess.Web.Code;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = new ApplicationConfiguration();
            configuration.Bind(Configuration, conf => conf.BindNonPublicProperties = true);
        }

        public ApplicationConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddTypedRouting();

            services.AddAuthentication("Cookie")
                    .AddCookie("Cookie");

            services.AddSingleton<IPessRepository, PessXmlRepository>();
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
