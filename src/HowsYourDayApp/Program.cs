using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HowsYourDayApp;
using HowsYourDayApp.Services;
using HowsYourDayApp.HttpHandlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("HowsYourDayApp", client =>
{
    client.BaseAddress = new Uri("https://localhost:7274/");
}).AddHttpMessageHandler<CookieHandler>();
builder.Services.AddTransient<CookieHandler>();

builder.Services.AddScoped<DayService>();
builder.Services.AddScoped<AuthenticationService>();

await builder.Build().RunAsync();
