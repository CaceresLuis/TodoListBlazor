using Blazorise;
using Blazorise.Material;
using TodoListBlazor.web;
using Blazorise.Icons.Material;
using TodoListBlazor.web.Services;
using TodoListBlazor.web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddMaterialProviders()
    .AddMaterialIcons();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7263/") });

builder.Services.AddScoped<ITodoService, TodoService>();

await builder.Build().RunAsync();
