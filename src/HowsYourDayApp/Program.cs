using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HowsYourDayApp;
using HowsYourDayApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://127.0.0.1:5022/") });

builder.Services.AddScoped<DayService>();
builder.Services.AddScoped<AuthenticationService>();

await builder.Build().RunAsync();
