using DesafioDEV.Interfaces.Repository;
using DesafioDEV.Interfaces.Service;
using DesafioDEV.Repository;
using DesafioDEV.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DesafioDEV
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHarvestService, HarvestService>();
            services.AddScoped<IHarvestRepository, HarvestRepository>();
            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            services.AddScoped<ITreeService, TreeService>();
            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<HttpClient>();

            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
