using AngelSystem_Estacionamento.Infrastructure.IoC;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
    {
        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Estacionamento API",
            Description = "Estaciomaneto API - Para cadastar, alterar e excluir Clientes, Veículos e Registros de entrada e saída",
            Version = "v1"
        });

        var xmlFile = $"{typeof(Program).Assembly.GetName().Name}.xml";
        var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        s.IncludeXmlComments(filePath);
    });

//Adicionar o IoC
builder.Services.AddRegistrosServico();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Estacionamento v1"); });    


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
