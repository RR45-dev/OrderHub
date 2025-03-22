using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orderhub; // Import the SignalR Hub

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR(); // ✅ Register SignalR

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.MapBlazorHub();
app.MapHub<HubClass>("/orderHub"); // ✅ Ensure the Hub is correctly mapped
app.MapFallbackToPage("/_Host");

app.Run();
