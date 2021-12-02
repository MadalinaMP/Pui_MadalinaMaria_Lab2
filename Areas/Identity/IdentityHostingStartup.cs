﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pui_MadalinaMaria_Lab2.Data;

[assembly: HostingStartup(typeof(Pui_MadalinaMaria_Lab2.Areas.Identity.IdentityHostingStartup))]
namespace Pui_MadalinaMaria_Lab2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddIdentity<IdentityUser, IdentityRole>(options =>
                        options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}