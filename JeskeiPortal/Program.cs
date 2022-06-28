using JeskeiPortal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Nethereum.Metamask;
using Nethereum.Metamask.Blazor;
using Nethereum.UI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IMetamaskInterop, MetamaskBlazorInterop>();
builder.Services.AddSingleton<MetamaskInterceptor>();
builder.Services.AddSingleton<MetamaskHostProvider>();
builder.Services.AddSingleton<IEthereumHostProvider>(serviceProvider =>
{
    return serviceProvider.GetService<MetamaskHostProvider>();
});
builder.Services.AddSingleton<NethereumSiweAuthenticatorService>();

// register the Telerik services
builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();
