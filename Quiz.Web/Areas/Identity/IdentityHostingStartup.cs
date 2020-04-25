using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Models;
using Quiz.Web.Data;

[assembly: HostingStartup(typeof(Quiz.Web.Areas.Identity.IdentityHostingStartup))]
namespace Quiz.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDefaultIdentity<User>(options => 
                  //  options.SignIn.RequireConfirmedAccount = false)
                    //    .AddRoles<Role>()
                      //  .AddEntityFrameworkStores<QuizDbContext>();
            });
        }
    }
}