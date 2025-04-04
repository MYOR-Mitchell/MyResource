using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyResource.Web;
using MyResource.Services.ThoughtCatcher;
using MyResource.Services.Palettes;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ThoughtService>();
builder.Services.AddScoped<PaletteService>();


builder.Services.AddScoped(_ => new HttpClient {
    BaseAddress = new Uri("https://localhost:7049")
});


await builder.Build().RunAsync();

