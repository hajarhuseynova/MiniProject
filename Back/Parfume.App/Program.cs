using ChatApp.Hubs;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.ServiceRegistration;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));


void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    //else
    //{
    //    app.UseExceptionHandler("/Home/Error");
    //    app.UseHsts();
    //}
}

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSignalR();


builder.Services.AddHttpContextAccessor();

builder.Services.Register(builder.Configuration);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{

    //app.UseExceptionHandler("/notfound/index");
    //app.UseStatusCodePagesWithReExecute("/notfound/index/{0}");
    //app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapHub<ChatHub>("/chatHub");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "admin/{controller=Account}/{action=Login}/{id?}"
        );
    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}"
       );
    endpoints.MapControllerRoute(
       name: "error",
       pattern: "{*url}",
       defaults: new { controller = "Home", action = "Error" }
   );
}
);


app.Run();
