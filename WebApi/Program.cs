using Application;
using Infrastructure;
using Persistence;
using Presentation;
using Serilog;
using WebApi.Utils;

var builder = WebApplication.CreateBuilder(args);

if (args.Length > 0 && (args[0] == "seed" || args[0] == "export-data"))
{
    await CommandLineTool.Run(args, builder.Configuration);
    return;
}

builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPresentation();

builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();