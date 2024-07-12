using API.Services.Implementations;
using API.Services.Interfaces;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion para el API

builder.Services.AddDbContext<VeteProV2Context>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();


//Mascotas
builder.Services.AddScoped<IMascotaDAL, MascotaDALImpl>();
builder.Services.AddScoped<IMascotaService, MascotaService>();

//Citas
builder.Services.AddScoped<ICitasDAL, CitasDALImpl>();
builder.Services.AddScoped<ICitaService, CitaService>();

//Desparasitaciones
builder.Services.AddScoped<IDesparasitacionesVacunaDAL, DesparasitacionesVacunaDALImpl>();
builder.Services.AddScoped<IDesparasitacionesVacunaService, DesparacitacionesVacunaService>();

//Medicamentos
builder.Services.AddScoped<IMedicamentoDAL, MedicamentoDALImpl>();
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();

//


//Razas
builder.Services.AddScoped<IRazasDAL, RazasDALImpl>();
builder.Services.AddScoped<IRazasService, RazasService>();


// tipos mascotas

builder.Services.AddScoped<ITiposMascotasDAL, TiposMascotasDALImpl>();
builder.Services.AddScoped<ITiposMascotasService, TiposMascotasService>();

//Padecimientos 

builder.Services.AddScoped<IPadecimientosDAL, PadecimientosDALImpl>();
builder.Services.AddScoped<IPadecimientosService, PadecimientosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
