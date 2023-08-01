using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//combine endpoint: 
var combine_endpoint_group = app.MapGroup("/combine");
combine_endpoint_group.MapPost("/", (MouseCombineRequest request) => 
    {
        //TODO: create async task to process combined shapes
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

app.Run();
