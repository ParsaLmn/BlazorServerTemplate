using Application.Interfaces;
using Application.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped(sp =>
{
    HttpClient httpClient = new(sp.GetRequiredService<AppHttpClientHandler>())
    {
        BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>().GetApiServerAddress())
    };

    return httpClient;
});

builder.Services.AddScoped<AppHttpClientHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();
builder.Services.AddScoped(sp => (AppAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();
builder.Services.AddScoped<IWebServiceClient, WebServiceClient>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();



builder.Services.AddLocalization(options => options.ResourcesPath = "Shared.Resources");
var localizeOptions = new RequestLocalizationOptions()
                .SetDefaultCulture("fa-IR")
                .AddSupportedCultures("en-US", "fa-IR")
                .AddSupportedUICultures("en-US", "fa-IR");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseRequestLocalization(localizeOptions);
app.MapControllers();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
