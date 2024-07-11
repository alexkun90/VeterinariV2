using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuracion FrontEnd


builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

//Mascota
builder.Services.AddScoped<IMascotaHelper, MascotaHelper>();
//Cita
builder.Services.AddScoped<ICitaHelper, CitaHelper>();
//DesparasitacionesVacunas
builder.Services.AddScoped<IDesparasitacionesVacunaHelper, DesparasitacionesVacunaHelper>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
