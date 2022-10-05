using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HealthAssessment.Models;
using HealthAssessment.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text.Json.Serialization;
using System.Text.Json;
using Library.Filters;

namespace HealthAssessment
{
    public class Startup
    {
        IHostEnvironment HostEnvironment { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors()
            //// Add useful interface for accessing the ActionContext outside a controller.
            //.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
            //// Add useful interface for accessing the HttpContext outside a controller.
            //.AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            //// Add useful interface for accessing the IUrlHelper outside a controller.
            //.AddScoped<IUrlHelper>(x => x
            //    .GetRequiredService<IUrlHelperFactory>()
            //    .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext))
            //.AddMvcCore(options =>
            //{
            //    options.Filters.Add(new ValidateModelFilter()); // Validate model. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#model-validation
            //                options.Filters.Add(new CacheControlFilter());  // Add "Cache-Control" header. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#cache-control
            //            })
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.IgnoreNullValues = true;
            //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    options.JsonSerializerOptions.WriteIndented = HostEnvironment.IsDevelopment();
            //})
            //.AddApiExplorer()
            //.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);



            services.AddControllers();
            services.AddSwaggerGen();
            services.AddDbContext<DBContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });
            services.AddTransient<UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthAssessment v1"));
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#cross-origin-resource-sharing-cors-and-preflight-requests
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
