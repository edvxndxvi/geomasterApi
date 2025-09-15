using geomasterApi.Services;
using geomasterApi.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(configurationSwagger =>
{
    configurationSwagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GeoMaster API",
        Version = "v1",
        Description = "API para cálculos geométricos 2D e 3D.",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    configurationSwagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();
builder.Services.AddScoped<IValidacoesService, ValidacoesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(configurationSwagger =>
    {
        configurationSwagger.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoMaster API v1");
        configurationSwagger.RoutePrefix = string.Empty; //Define que o swagger UI seja a página inicial
    });  
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
