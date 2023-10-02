using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Quantum.BlazorServer.Hubs;
using Quantum.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddSingleton(x =>
{
    var hubConnectionBuilder = new HubConnectionBuilder();
    return hubConnectionBuilder.WithUrl(new Uri("https://localhost:7183/NoteHub")).Build();
});
builder.Services.AddResponseCompression(opt =>
{
    opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});
builder.Services.AddPostgreSql(builder.Configuration.GetConnectionString("postgreSql"));
builder.Services.AddData();

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
app.UseResponseCompression();
app.MapHub<NoteHub>("/NoteHub");
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
