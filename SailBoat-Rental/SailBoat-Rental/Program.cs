using Sailboat_Rental.Models;
using SailBoat_Rental.Services;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option => {
    option.AddPolicy("AllowSpecificOrigin", policy => policy.WithOrigins("http://localhost"));
    option.AddPolicy("AllowGetMethod", policy => policy.WithMethods("GET"));
});

// Add services to the container.
builder.Services.Configure<StoreSailboatDatabaseSetting>(builder.Configuration.GetSection("StoreSailboatDatabaseSetting"));
builder.Services.AddSingleton<CategoryService>();
;
builder.Services.AddSingleton<LessorServices>();
builder.Services.AddSingleton<BoatService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        a =>
        {

            a.AllowAnyOrigin()
            .AllowAnyHeader()
             .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
app.UseCors("AllowSpecificOrigin");
app.UseCors(option => option.WithHeaders("accept", "content-type", "origin"));
app.UseCors(option => option.AllowCredentials());
app.MapControllers();

app.Run();
