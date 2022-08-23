using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Data;
using Planner.Models;
using Planner.Services;
using Planner.Services.Interfaces;

namespace Planner
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
            services.AddDbContext<ApplicationDbContext>(options =>
                // changed .UseSqlServer -> .UseNpgsql
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            // Changed .AddDefaultIdentity -> .AddIdentity
            // Added parameters of AppUser and IdentityRole
            services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                // Additional methods added
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            // Registering the BTRoleService and IBTRoleService
            services.AddScoped<IBTRolesService, BTRolesService>();

            // Registering th TeamInfoService and ITeamInfoService
            services.AddScoped<ITeamInfoService, TeamInfoService>();

            // Registering the ProjectService and IProjectService
            services.AddScoped<IProjectService, ProjectService>();

            // Registering the TicketService and ITicketService
            services.AddScoped<ITicketService, TicketService>();

            // Registering the TicketHistoryService and ITicketHistoryService
            services.AddScoped<ITicketHistoryService, TicketHistoryService>();

            // Registering the NotificationService and INotificationService
            services.AddScoped<INotificationService, NotificationService>();

            // Registering the InviteService and IInviteService
            services.AddScoped<IInviteService, InviteService>();

            // Registering the FileService and IFileService
            services.AddScoped<IFileService, FileService>();

            // Registering the EmailService and IEmailSender
            services.AddScoped<IEmailSender, EmailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
        }
    }
}
