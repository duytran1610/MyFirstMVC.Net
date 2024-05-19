using System.Net;
using Microsoft.AspNetCore.Mvc.Razor;
using MyFirstApp.Services;
using MyFirstApp.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
builder.Services.Configure<RazorViewEngineOptions>(options => {
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // {0} -> ten Action
    // {1} -> ten Controller
    // {2} -> ten Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

// builder.Services.AddSingleton<ProductService>();
// builder.Services.AddSingleton<ProductService, ProductService>();
// builder.Services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductService),typeof(ProductService));
builder.Services.AddSingleton<PlanetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.AddStatusCodePage();



app.MapRazorPages();

app.MapGet("/sayhi", async (context) =>
{
    await context.Response.WriteAsync($"Hello MVC {DateTime.Now}");
});

// app.MapControllers
// app.MapControllerRoute
// app.MapDefaultControllerRoute
// app.MapAreaControllerRoute

// URL = start-here
// controller -> 
// action ->
// area ->

// [AcceptVerbs]

// [Route]

// [HttpGet]
// [HttpPost]
// [HttpPut]
// [HttpDelete]
// [HttpHead]
// [HttpPatch]

// Area

app.MapControllerRoute(
    name: "first",
    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
    defaults: new {
        controller = "First",
        action = "ViewProduct"
    }
);

app.MapAreaControllerRoute(
    name: "product",
    areaName: "ProductManage",
    pattern: "/{controller}/{action=Index}/{id?}"
);


// controller no area
// URL: /{controller}/{action}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
