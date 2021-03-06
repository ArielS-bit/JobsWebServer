using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration; //This one adds the GetConnectionString method to Configuration
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using JobsWebServerBL.Models;


namespace JobsWebServer
{
    public class Startup
    {
        //Constructor need to be added to get an instance of configuration file (appsettings.json)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Controllers and set the Json Serializer to handle loop referencing
            services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions
                        .ReferenceHandler = ReferenceHandler.Preserve);

            #region Add Session Support
            //The following two commands set the Session state to work!
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(180);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion

            //The following set the connection string to the DB and DB context!
            #region Add DB Context Support
            string connectionString = this.Configuration.GetConnectionString("IJobDB");

            services.AddDbContext<IJobDBContext>(options => options
                                                                .UseSqlServer(connectionString));
                                                                //.UseLazyLoadingProxies());
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                    await next();
                    if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.NotFound && context.Request.Path.Value.Contains("jpg"))
                    {
                        context.Request.Path = new PathString(@"/Images/DefualtProfile.PNG");
                        await next();
                    }

            });

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.NotFound &&
                context.Request.Path.Value.Contains("jpg"))
                {
                    if (context.Request.Path.Value.Contains("ProfileImages"))
                        context.Request.Path = new PathString(@"/ProfileImages/defualtProfile.png");
                    else
                        context.Request.Path = new PathString(@"/JobOfferImages/defualt.png");
                    await next();
                }
                
            });

            app.UseStaticFiles(); //Added to have the wwwroot folder and server to accept calls to static files
            app.UseRouting();
            app.UseSession(); //Tell the server to use sessions!


            app.UseEndpoints(endpoints =>
            {
                //Map all routings for controllers 
                endpoints.MapControllers();
               
            });
        }
    }
}
