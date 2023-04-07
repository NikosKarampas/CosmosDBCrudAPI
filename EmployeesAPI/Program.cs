using System;
using System.Text.Json;
using Azure.Identity;
using EmployeesAPI.Extensions;
using EmployeesAPI.Repositories;
using EmployeesAPI.SystemTextJson;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jsonSerializerOptions = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

//Configure CosmosSystemTextJsonSerializer
var serializer = new CosmosSystemTextJsonSerializer(jsonSerializerOptions);

if (builder.Environment.IsProduction())
{
    builder.Services.AddSingleton<CosmosClient>(serviceProvider => 
        new CosmosClient(Environment.GetEnvironmentVariable("CosmosDB_ENDPOINT"), new DefaultAzureCredential(), new CosmosClientOptions { Serializer = serializer }));
}
else
{
    builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
        new CosmosClient(config.GetConnectionString("CosmosDbConnectionString"), new CosmosClientOptions { Serializer = serializer }));
}

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseGlobalExeptionHandling();

app.MapControllers();

app.Run();
