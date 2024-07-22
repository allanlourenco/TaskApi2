using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaskApi.Application;
using TaskApi.Application.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ApiTask", client =>
{
    client.BaseAddress = new Uri("https://localhost:7037"); // Substitua pelo URL da API externa
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddScoped<TaskService>();

await builder.Build().RunAsync();
