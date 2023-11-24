using PerfectMatch.WEB;
using PerfectMatch.WEB.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://perfectmatchapi2023.azurewebsites.net/") });
builder.Services.AddScoped<IRepository , Repository>();
builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
 