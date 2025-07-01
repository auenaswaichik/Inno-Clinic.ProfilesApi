using Api.Extensions;
using Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureRepositories();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureValidators();
builder.Services.ConfigureDataBaseContext(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();