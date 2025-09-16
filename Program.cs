using geomasterApi.Factory;
using geomasterApi.Interfaces;
using geomasterApi.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(configurationSwagger =>
{
    configurationSwagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API CP4 GeoMaster",
        Version = "v1",
        Description = "TODO",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    configurationSwagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<ICalculadoraService, CalculadoraService>();
builder.Services.AddSingleton<IFactoryForma, FactoryForma>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(configurationSwagger =>
    {
        configurationSwagger.SwaggerEndpoint("/swagger/v1/swagger.json", "API CP4 GeoMaster v1");
        configurationSwagger.RoutePrefix = string.Empty; //Define que o swagger UI seja a página inicial
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
