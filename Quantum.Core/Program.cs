
using Quantum.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<NoteRepository>();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoint => endpoint.MapControllerRoute(
    "default", "{controller=Home}/{action=Index}/{id?}"));
app.Run();
