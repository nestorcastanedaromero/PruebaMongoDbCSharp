using API;
using API.Utilidades;
using Compartidos.Infraestructura;
using Resolver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ConfiguracionConexionMongo>(builder.Configuration.GetSection("ConfiguracionMongo"));
builder.Services.ResolverDependencias();
builder.Services.AddAuthorization();
builder.Services.ValidarToken();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MiddlewareManejadorErrores>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
