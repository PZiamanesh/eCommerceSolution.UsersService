using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ioc container

builder.Services.AddCore();

builder.Services.AddInfrastructure();

builder.Services.AddControllers()
    .AddJsonOptions(cnfg =>
    {
        cnfg.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(CoreConfigs).Assembly);

builder.Services.AddFluentValidationAutoValidation();

// request pipeline

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.Run();
