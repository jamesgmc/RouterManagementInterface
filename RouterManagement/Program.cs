using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RouterManagement.Data;
using RouterManagement.Data.Services;
using RouterManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<StatusService>();

// Configure API URL and Mock setting
var useMockService = builder.Configuration.GetValue<bool>("UseMockService");
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:3000";

//if (builder.Environment.IsDevelopment() || useMockService)
if (useMockService)
{
    builder.Services.AddSingleton<IHostManagementService, MockHostManagementService>();
}
else
{
    builder.Services.AddHttpClient<IHostManagementService, HostManagementService>((services, client) =>
    {
        client.BaseAddress = new Uri(apiBaseUrl);
    }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseCookies = false });
}

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
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
