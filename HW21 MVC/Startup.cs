using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ORM;
using Microsoft.Extensions.Configuration;
using HW21_MVC.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HW21_MVC.Services;

namespace HW21_MVC
{
    public class Startup
    {
        public IConfiguration Config { get;}//Config file(stores connection string)

        //ctor initializes Configuration file // DI
        public Startup(IConfiguration config)
        {
            Config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            
            //Binding Configuration with appsettings.json
            Config.Bind("Project", new Config());

            //Adding DB Context to create ORM System for managing data base
            services.AddDbContext<DataContext>(x => x.UseSqlServer(
                Configuration.Config.ConnectionString                
                )) ;

            //Add Repository that will store dbSets form data base tables using DI
            services.AddScoped<IRepository, EFRepository>();

            //Identity System Configuring
            services.AddIdentity<IdentityUser, IdentityRole>(
                opts=>
                {
                    opts.User.RequireUniqueEmail = true;
                    opts.Password.RequiredLength = 10;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                }
                ).AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(
                o =>
                {
                    o.Cookie.HttpOnly = true;
                    o.LoginPath = "/Account/Login";
                    o.AccessDeniedPath = "/Account/AccessDenied";
                    o.SlidingExpiration = true;
                }
                );

            services.AddAuthorization(
                o=>
                {
                    o.AddPolicy("AdminPolicy", policy=>
                    { policy.RequireRole("admin"); });

                    o.AddPolicy("UserPolicy", policy =>
                    { policy.RequireRole("user"); });
                }
                );

            //Add MVC functions
            services.AddControllersWithViews(
                s=>                                   
                {
                    s.Conventions.Add(new UserAreaAuthorization("Admin",
                        "AdminPolicy"));

                    s.Conventions.Add(new UserAreaAuthorization("User",
                        "UserPolicy"));
                    //Admin - area where admincontroller is stored
                }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();//Using Static files (wwwroot)

            app.UseRouting();//Use routing system

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            //Endpoint System to enable start up page
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "admin", "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    "user", "{area:exists}/{controller=User}/{action=Index}"
                    );

                endpoints.MapControllerRoute(
                    "home", "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
