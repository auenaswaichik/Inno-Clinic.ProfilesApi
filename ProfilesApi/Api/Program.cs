using DotNetEnv;
using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Env.Load();

var connection = Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.AddRepositories();
builder.Services.AddMediatr();
builder.Services.AddValidators();
builder.Services.AddDataBaseContext(connection);
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