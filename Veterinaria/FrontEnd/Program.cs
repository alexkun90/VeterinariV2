using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(x => x.LoginPath = "/account/login");


builder.Services.AddSession();


//Configuracion FrontEnd
builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

//Mascota
builder.Services.AddScoped<IMascotaHelper, MascotaHelper>();
//Cita
builder.Services.AddScoped<ICitaHelper, CitaHelper>();
//DesparasitacionesVacunas
builder.Services.AddScoped<IDesparasitacionesVacunaHelper, DesparasitacionesVacunaHelper>();
//Medicamentos
builder.Services.AddScoped<IMedicamentoHelper, MedicamentoHelper>();
//Razas
builder.Services.AddScoped<IRazasHelper, RazasHelper>();
// Padecimientos
builder.Services.AddScoped<IPadecimientosHelper, PadecimientosHelper>();
// tipos mascotas
builder.Services.AddScoped<ITiposMascotasHelper, TiposMascotasHelper>();
//usuarios
builder.Services.AddScoped<IUsuarioHelper, UsuarioHelper>();

//Security
builder.Services.AddScoped<ISecurityHelper, SecurityHelper>();


//Soporte Paginas Razor
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
