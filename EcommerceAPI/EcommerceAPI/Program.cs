using AutoMapper;
using Ecommerce.AccessData;
using Ecommerce.AccessData.Commands;
using Ecommerce.AccessData.Queries;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Services;
using EcommerceAPI.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ADD CORS
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();
builder.Services.AddTransient<IPerfilService, PerfilService>();
builder.Services.AddTransient<IPerfilQuery, PerfilQuery>();
builder.Services.AddTransient<IPerfilCommand, PerfilCommand>();

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
