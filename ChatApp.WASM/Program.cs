using ChatApp.WASM;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7161/api/") });




//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//    policy =>
//    {
//        policy.AllowAnyOrigin(); // izin verilen kaynaðý ayarlayýn
//    });
//});
await builder.Build().RunAsync();
