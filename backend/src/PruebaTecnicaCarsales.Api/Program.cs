using PruebaTecnicaCarsales.Api.Application.Interfaces;
using PruebaTecnicaCarsales.Api.Application.Services;
using PruebaTecnicaCarsales.Api.Common.Middleware;
using PruebaTecnicaCarsales.Api.Infrastructure.HttpClients;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IRickAndMortyClient, RickAndMortyClient>();

builder.Services.AddScoped<IEpisodeService, EpisodeService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin(); 
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
