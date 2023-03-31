using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient(
    "BlazorHosted.ServerAPI",
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
);

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(
    sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorHosted.ServerAPI")
);

await builder.Build().RunAsync();
