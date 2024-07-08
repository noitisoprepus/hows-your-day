using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HowsYourDayApp;
using HowsYourDayApp.Services;
using HowsYourDayApp.HttpHandlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CookieHandler>();
builder.Services.AddTransient<RefreshHandler>();

string baseAddress;
if (builder.HostEnvironment.IsDevelopment())
{
    baseAddress = "https://localhost:7274/";
}
else
{
    baseAddress = "http://localhost:5000/";
}

builder.Services.AddHttpClient("HowsYourDayApp", client =>
{
    client.BaseAddress = new Uri(baseAddress);
})
    .AddHttpMessageHandler<CookieHandler>()
    .AddHttpMessageHandler<RefreshHandler>();

// Register the HttpClient for TokenService
builder.Services.AddHttpClient<TokenService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
})
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddScoped<DayService>();
builder.Services.AddScoped<AuthenticationService>();

await builder.Build().RunAsync();
