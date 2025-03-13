using UsersMicroService.Core;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using UsersMicroService.API.Middlewares;
using UsersMicroService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ioc container

builder.Services.AddCore();
builder.Services.AddInfrastructure();

builder.Services.AddControllers()
    .AddJsonOptions(cnfg =>
    {
        cnfg.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        cnfg.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(CoreConfigs).Assembly);

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(ops =>
{
    ops.AddDefaultPolicy(bldr =>
    {
        bldr.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// request pipeline

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
