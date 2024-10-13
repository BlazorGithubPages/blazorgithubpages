using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPages;
using BlazorPages.Util;
using Serilog;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => http);

var appSettings = await http.GetFromJsonAsync<AppSettings>("appsettings.json", new System.Text.Json.JsonSerializerOptions() { Converters = { new UnknownEnumConverter() } });
builder.Services.AddSingleton(appSettings ?? new());

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.BrowserConsole()
    .CreateLogger();

await builder.Build().RunAsync();
