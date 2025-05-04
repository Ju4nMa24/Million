using Million.Application.DIConfiguration;
using Million.Common.DIConfiguration;
using Million.Domain.DIConfiguration;
using Million.External.DIConfiguration;
using Million.Persistence.DIConfiguration;
using HealthChecks.UI.Client;
using Million.Api.DIConfiguration;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddDomain()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyMethod().AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseWatchDogExceptionLogger();
#region Health Check Configurations
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
#endregion
#region WatchDog Configurations
app.UseWatchDog(configuration =>
{
    configuration.Serializer = WatchDog.src.Enums.WatchDogSerializerEnum.Newtonsoft;
    configuration.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    configuration.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});
#endregion
app.MapControllers();

app.Run();
