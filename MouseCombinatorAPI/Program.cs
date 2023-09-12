using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Diagnostics;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Instrumentation.Runtime;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
            .AddService(serviceName: builder.Environment.ApplicationName))
        .WithMetrics(metrics => metrics
            .AddRuntimeInstrumentation()
            .AddConsoleExporter((exporterOptions, metricReaderOptions) =>
            {
                metricReaderOptions.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 1000;
            }));

var app = builder.Build();

//combine endpoint: 
var combine_endpoint_group = app.MapGroup("/combine");
combine_endpoint_group.MapPost("/", (MouseCombineRequest request) => 
    {
        //TODO: enqueue request, and return appropriate status code
        foreach (int img_id in request.mouse_ids_to_combine) {
            
        }
        return Results.StatusCode(202);
    });

var list_endpoint_group = app.MapGroup("/list");
list_endpoint_group.MapGet("/", () => 
    {
        //TODO: query database and return list of available mice
        return Results.StatusCode(200);
    });

var health_endpoint = app.MapGet("/health", () => 
    {
        return "Healthy!";
    }
);

//debug

// MouseCombineRequest testReq = new MouseCombineRequest();

// Console.WriteLine(JsonSerializer.Serialize(testReq));

//terminal middleware

app.Run(context =>
{
    context.Response.StatusCode = 404;
    return Task.CompletedTask;
});

app.Run();