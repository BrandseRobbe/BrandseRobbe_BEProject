using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quiz.Models;
using Quiz.Models.Repositories;
using Quiz.Web.Data;

namespace Quiz.API
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
            services.AddControllers();

            //1.1 loophandling verhinderen
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.RespectBrowserAcceptHeader = true;
            }).AddNewtonsoftJson(options =>
            {
                //circulaire referenties verhinderen door navigatie props
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //2.1. Context
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<QuizDbContext>(options => options.UseSqlServer(connectionString));

            //2.2 Identity
            services.AddIdentity<Person, IdentityRole>()
                .AddEntityFrameworkStores<QuizDbContext>();

            //3 Registraties van Repos
            services.AddScoped<IPersonRepo, PersonRepo>();
            services.AddScoped<IQuizRepo, QuizRepo>();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "ToDo_API", Version = "v1.0" });
            //});
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
