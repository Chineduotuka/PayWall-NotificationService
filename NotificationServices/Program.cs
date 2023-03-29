using FluentValidation;
using NotificationServices.API;
using NotificationServices.API.Extensions;
using NotificationServices.Infrastructure.Repository;
using NotificationServicesAPI.Core.Interfaces;
using Serilog;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isDevelopment = environment == Environments.Development;
IConfiguration config = ConfigurationSetUp.GetConfig(isDevelopment);
LogSettings.SetUpSerilog(config);
try
{
    Log.Logger.Information("Notification logging setting up");
    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;

    // Add services to the container.

  
    builder.Services.AddSwaggerExtension();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();
    builder.Services.AddDbContextAndConfigurations(builder.Environment, builder.Configuration);
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddSignalR();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
            "NotificationServices API");
    });
    app.UseDeveloperExceptionPage();
}

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.Map<>
    app.MapControllers();

    app.Run();
}
catch(Exception e)
{
    Log.Logger.Fatal(e.StackTrace, "The application failed to start correctly");
}
finally
{
    Log.CloseAndFlush();
}



