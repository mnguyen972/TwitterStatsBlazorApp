using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Linq;
using TwitterStatsBlazorApp.Server.Data;
using TwitterStatsBlazorApp.Server.Helpers;
using TwitterStatsBlazorApp.Server.Hubs;
using TwitterStatsBlazorApp.Server.Interfaces;
using TwitterStatsBlazorApp.Server.Middleware;
using TwitterStatsBlazorApp.Shared;
using ILogger = Serilog.ILogger;

namespace TwitterStatsBlazorApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddSingleton(Log.Logger);
            services.AddSingleton<IWorkerHelper, WorkerHelper>();
            services.AddSingleton<IWorker, Worker>();
            services.AddDbContext<TwitterStatsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TwitterStatsDB")));
            services.AddScoped<IDataRepository<TwitterStat>, TwitterStatsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.ConfigureExceptionHandler(log);

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<BroadcastHub>("/broadcastHub");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
