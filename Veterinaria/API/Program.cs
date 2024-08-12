using API.Services.Implementations;
using API.Services.Interfaces;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ConexionDB
builder.Services.AddDbContext<VeteProV2Context>(options =>
    options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection"))
        );

builder.Services.AddDbContext<AuthDBContext>(options =>
    options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection"))
        );
#endregion

#region Identity
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
        .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("proveedor")
        .AddEntityFrameworkStores<AuthDBContext>()
        .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});
#endregion

#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });
#endregion

#region DI
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

//Token
builder.Services.AddScoped<ITokenService, TokenService > ();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
