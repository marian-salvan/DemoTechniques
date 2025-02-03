using DemoTechniques.Strategies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddTransient<ICalculationStrategy, AdditionCalculationStrategy>()
    .AddTransient<ICalculationStrategy, SubstractionCalculationStrategy>()
    .AddTransient<ICalculationStrategy, MultiplicationCalculationStrategy>()
    .AddTransient<ICalculationStrategy, DivisionCalculationStrategy>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.MapGet("/calculate", ([FromQuery] double a, [FromQuery] double b, [FromQuery] string op) =>
//{
//    try
//    {
//        if (!Enum.TryParse<OperationType>(op, true, out var operationType))
//        {
//            return Results.BadRequest("Invalid operation");
//        }

//        return operationType switch
//        {
//            OperationType.ADDITION => Results.Ok(a + b),
//            OperationType.SUBSTRACTION => Results.Ok(a - b),
//            OperationType.MULTIPLICATION => Results.Ok(a * b),
//            OperationType.DIVISION => b == 0 ? Results.BadRequest("Division by zero") : Results.Ok(a / b),
//            _ => Results.BadRequest("Invalid operation type"),
//        };
//    } 
//    catch (Exception)
//    {
//        return Results.InternalServerError("Calculation error");
//    }
//})
//.WithName("Calculate");


app.MapGet("/calculate", ([FromQuery] double a, [FromQuery] double b, [FromQuery] string op,
    [FromServices] IEnumerable<ICalculationStrategy> calculationStrategies) =>
{
    try
    {
        if (!Enum.TryParse<OperationType>(op, true, out var operationType))
        {
            return Results.BadRequest("Invalid operation");
        }

        var strategiesDict = calculationStrategies.ToDictionary(s => s.OperationType);

        if (!strategiesDict.TryGetValue(operationType, out var strategy))
        {
            return Results.BadRequest("Invalid operation type");
        }

        return Results.Ok(strategy.Calculate(a, b));
    }
    catch (Exception)
    {
        return Results.InternalServerError("Calculation error");
    }
})
.WithName("Calculate");

app.Run();
