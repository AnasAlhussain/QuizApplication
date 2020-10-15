using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.WEB.Data;

[assembly: HostingStartup(typeof(QuizApp.WEB.Areas.Identity.IdentityHostingStartup))]
namespace QuizApp.WEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<QuizAppWEBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QuizAppWEBContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<QuizAppWEBContext>();
            });
        }
    }
}