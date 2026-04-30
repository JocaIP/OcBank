using OcBank.Application.Repositorios;
using OcBank.Application.UseCases.CriarUsuario;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger (documentação)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência
builder.Services.AddSingleton<UsuarioRepositorio>();
builder.Services.AddScoped<CriarUsuarioUseCase>();

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