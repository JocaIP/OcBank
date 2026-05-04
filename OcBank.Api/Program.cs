using Microsoft.EntityFrameworkCore;
using OcBank.Application.Repositories;
using OcBank.Application.UseCases.CriarUsuario;
using OcBank.Application.UseCases.ObterUsuarios;
using OcBank.Infrastructure.Data;
using OcBank.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔥 Injeção correta
builder.Services.AddScoped<CriarUsuarioUseCase>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ObterUsuariosUseCase>();
builder.Services.AddScoped<IContaRepositorio, ContaRepositorio>();

// 🔥 Banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();