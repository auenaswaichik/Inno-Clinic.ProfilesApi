using Api.Extensions;
using Api.Middleware;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.ConfigureAuthorization();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureValidators();
builder.Services.ConfigureDataBaseContext(builder.Configuration);
builder.Services.AddControllers();
builder.Services.ConfigureMassTransit(builder.Configuration);
builder.Host.ConfigureSerilog();

var app = builder.Build();

app.EnsureDatabaseMigration();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();