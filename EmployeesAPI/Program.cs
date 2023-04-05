using System.Text.Json;
using EmployeesAPI.Repositories;
using EmployeesAPI.SystemTextJson;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.

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

builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
    new CosmosClient(config.GetValue<string>("CosmosDB:ConnectionString"), new CosmosClientOptions { Serializer = serializer }));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
