using System;
using System.Threading.Tasks;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CFMCommon;

namespace CFMWeb
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.SlidingExpiration = true;
                  options.ExpireTimeSpan = TimeSpan.FromSeconds(86400);
                options.LoginPath = "/#/Login/1";
                  options.Events = new CookieAuthenticationEvents
                  {
                      OnRedirectToAccessDenied = context =>
                {
                      context.Response.StatusCode = 401;

                      return Task.CompletedTask;
                  }
              ,
                      OnRedirectToLogin = context =>
                {
                      context.Response.StatusCode = 401;

                      return Task.CompletedTask;
                  }
                  };


              });
            services.AddSingleton<IAuthorizationHandler, AuthorizationHandler>();
            services.AddElmah(options =>
            {

                options.ConnectionString = Configuration.GetSection("ConnectionStrings").GetSection("CFMDataConnectionString").Value; ;


            });
            services.AddAuthorization(
              options =>
                options.AddPolicy("CheckUserLoggedIn", policy => policy.Requirements.Add(new UserFuntionAuthorizationRequirement()))


            );

            services.AddAuthorization(
                options =>
                  options.AddPolicy("AdminRole", policy => policy.Requirements.Add(new UserFuntionAuthorizationRequirement("CFMAdmin")))
              );

            services.AddAuthorization(
                options =>
                  options.AddPolicy("CCHeadOfficeRole", policy => policy.Requirements.Add(new UserFuntionAuthorizationRequirement("CCHeadOfficeUser")))
              );

            services.AddAuthorization(
                options =>
                    options.AddPolicy("CFMUser", policy => policy.Requirements.Add(new UserFuntionAuthorizationRequirement("CFMAdmin,CFMUser")))
                );

            services.AddAuthorization(
                options =>
                    options.AddPolicy("RestrictedAccess", policy => policy.Requirements.Add(new UserFuntionAuthorizationRequirement("CFMAdmin,CCHeadOfficeUser,Supplier")))
                );
            services.AddAuthorization(
                options =>
                    options.AddPolicy("BudgetUsers", policy => policy.Requirements.Add(new UserFuntionAuthorizationRequirement(SystemRoleTypeEnum.CFMAdmin.ToString() + "," + SystemRoleTypeEnum.CFMUser + "," + SystemRoleTypeEnum.FinancialAdministrator + "," + SystemRoleTypeEnum.Supervisor)))
            );

      services.AddElmah(options => options.Path = "CCElmah");

            services.AddElmah(options =>
            {
          // This lambda determines whether user consent for non-essential cookies is needed for a given request.
          options.Path = "CCElmah";
                options.CheckPermissionAction = context =>
          {
                  if (context.User.Identity.IsAuthenticated)
                  {
                      var userRoles = context.User.FindFirst(c => c.Type == UserClaims.Roles.ToString()).Value;
                      if (!string.IsNullOrEmpty(userRoles))
                      {
                          foreach (string userRole in userRoles.Split(","))
                          {
                              if (userRole.ToLower() == SystemRoleTypeEnum.CFMAdmin.ToString().ToLower())
                              {
                                  return true;
                              }
                          }
                      }

                  }

                  return false;
              };

            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Error");
                // app.UseHsts();
            }

            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseElmah();
            app.UseSpaStaticFiles();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
          // To learn more about options for serving an Angular SPA from ASP.NET Core,
          // see https://go.microsoft.com/fwlink/?linkid=864501

          spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
              //spa.UseAngularCliServer(npmScript: "start");
          }
            });
        }
    }
}
