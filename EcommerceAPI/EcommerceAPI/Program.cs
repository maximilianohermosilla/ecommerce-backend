using AutoMapper;
using Ecommerce.AccessData;
using Ecommerce.AccessData.Commands;
using Ecommerce.AccessData.Queries;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Services;
using EcommerceAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//ADD CORS
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();

builder.Services.AddTransient<IPerfilService, PerfilService>();
builder.Services.AddTransient<IPerfilQuery, PerfilQuery>();
builder.Services.AddTransient<IPerfilCommand, PerfilCommand>();

builder.Services.AddTransient<IParametroService, ParametroService>();
builder.Services.AddTransient<IParametroQuery, ParametroQuery>();
builder.Services.AddTransient<IParametroCommand, ParametroCommand>();

builder.Services.AddTransient<ICategoriaProductoService, CategoriaProductoService>();
builder.Services.AddTransient<ICategoriaProductoQuery, CategoriaProductoQuery>();
builder.Services.AddTransient<ICategoriaProductoCommand, CategoriaProductoCommand>();

builder.Services.AddTransient<IEstadoService, EstadoService>();
builder.Services.AddTransient<IEstadoQuery, EstadoQuery>();
builder.Services.AddTransient<IEstadoCommand, EstadoCommand>();

builder.Services.AddTransient<IFormaEntregaService, FormaEntregaService>();
builder.Services.AddTransient<IFormaEntregaQuery, FormaEntregaQuery>();
builder.Services.AddTransient<IFormaEntregaCommand, FormaEntregaCommand>();

builder.Services.AddTransient<IEmpresaService, EmpresaService>();
builder.Services.AddTransient<IEmpresaQuery, EmpresaQuery>();
builder.Services.AddTransient<IEmpresaCommand, EmpresaCommand>();

// Configurar AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile()); // Agrega aquí tu clase de perfil
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregar DBContext
builder.Services.AddDbContext<EcommerceDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//SERILOG
builder.Host.UseSerilog();

Serilog.Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// USE CORS
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
