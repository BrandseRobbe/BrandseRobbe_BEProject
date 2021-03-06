using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quiz.Models;
using Quiz.Models.Data;
using Quiz.Models.Repositories;
using Quiz.Web.Data;
using System;

namespace Quiz.Web
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
            services.AddDbContext<QuizDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")),
                                ServiceLifetime.Transient);



            services.AddIdentity<User, Role>() //NIET de AddDefaultIdentity()) 
                .AddEntityFrameworkStores<QuizDbContext>()
                .AddRoles<Role>()
                .AddDefaultTokenProviders() //voorkomt error: NotSupportedException: No IUserTwoFactorTokenProvider<TUser> named 'Default' is registered.
                .AddDefaultUI(); //voorkomt error op registratie pagina: 'Unable to resolve service for type IEmailSender while attempting to activate RegisterModel'


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });
            services.ConfigureApplicationCookie(options =>
            {   // Cookie settings 
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

            //services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            services.AddScoped<IGameRepo, GameRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IQuizRepo quizRepo, IQuestionRepo questionRepo, QuizDbContext context, RoleManager<Role> roleMgr, UserManager<User> userMgr)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            QuizDbContextExtensions.SeedQuiz(quizRepo, questionRepo).Wait();
            QuizDbContextExtensions.SeedRoles(roleMgr).Wait();
            QuizDbContextExtensions.SeedUsers(userMgr).Wait();
        }
    }
}
