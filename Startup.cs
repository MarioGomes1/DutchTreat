using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//adds all MVC services(dependency injection)

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           // app.UseDefaultFiles();//finds the .html files and tells static to serve the file
            app.UseStaticFiles();//serves file
            app.UseNodeModules(env);
            app.UseMvc(cfg =>
            {

                cfg.MapRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "Home", Action = "Index" });
                //if you see an url come in after the server name and port name and looks like users/manage...find the controller called user management and execute the action called Index
                //routes are way that mvc will look at pattern of the url and try to map it to a controller 
            });

        }
    }
}
