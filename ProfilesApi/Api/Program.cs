using DotNetEnv;
using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Env.Load();

var connection = Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.ConfigureRepositories();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureValidators();
builder.Services.ConfigureDataBaseContext(connection);
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();