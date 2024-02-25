using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Reflection.Emit;
// using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Razor;
using AppMvc.Net.Services;

public class Startup
{
    public static string ContentRootPath {get;set;}
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        ContentRootPath = env.ContentRootPath;
    }

    public IConfiguration Configuration {get;}

    public void ConfigureServices(IServiceCollection services)
    {   
       services.AddControllersWithViews(); 
       services.AddRazorPages();
       // services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); => Tu dong duoc dang ki
       services.Configure<RazorViewEngineOptions>(options => {
           // view/controller/action.cshtml
           // myview/controller/action.cshtml
           // {0} -> action {1} -> controller {2} -> Area
          
           options.ViewLocationFormats.Add("/MyView/{1}/{0}" +  RazorViewEngine.ViewExtension);
       });

       services.AddSingleton(typeof(ProductService), typeof(ProductService));

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // xac dinh danh tinh
        app.UseAuthorization(); // xac thuc quyen truy cap

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            endpoints.MapRazorPages();
        });
    }
}

               
                