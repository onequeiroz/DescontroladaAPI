using DescontroladaAPI;
using DescontroladaAPI.Infra;
using DescontroladaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>(opt => opt
    .UseInMemoryDatabase(builder.Configuration.GetConnectionString("DescontroladaDb"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configures the automatic BadRequest response of invalid ModelState in ApiController and customizes the object response
// Using the return in this configuration, there is no need to validate the ModelState in every controller post / put method
builder.Services.Configure<ApiBehaviorOptions>(o =>
{
    o.InvalidModelStateResponseFactory = (actionContext) =>
    {
        return ReturnObject.InvalidModelStateResponse(success: false, message: actionContext.ModelState.Values.First().Errors[0].ErrorMessage);
    };
});

DependencyInjection.Configure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cross domain requests
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CustomExceptionMiddleware>();

app.MapControllers();

app.Run();
