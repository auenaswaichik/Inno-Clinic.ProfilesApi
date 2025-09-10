using Api.Extensions;
using Api.Middleware;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowCredentials()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureAuthorization();

builder.Services.ConfigureRepositories();

builder.Services.ConfigureMediatr();

builder.Services.ConfigureValidators();

builder.Services.ConfigureDataBaseContext(builder.Configuration);

builder.Services.AddControllers();

builder.Services.ConfigureMassTransit(builder.Configuration);

builder.Host.ConfigureSerilog();

var app = builder.Build();

app.UseCors("AllowAll");

app.EnsureDatabaseMigration();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();