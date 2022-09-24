using Sailboat_Rental.Model;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using SailBoat_Rental.Repository;
using SailBoat_Rental.Service;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option => {
    option.AddPolicy("AllowSpecificOrigin", policy => policy.WithOrigins("http://localhost"));
    option.AddPolicy("AllowGetMethod", policy => policy.WithMethods("GET"));
});

// Add services to the container.
builder.Services.Configure<StoreSailboatDatabaseSetting>(builder.Configuration.GetSection("StoreSailboatDatabaseSetting"));

builder.Services.AddSingleton<LessorRepository>();
builder.Services.AddSingleton<CategoryRepository>();
builder.Services.AddSingleton<BoatRepository>();
builder.Services.AddSingleton<BookingRepository>();

builder.Services.AddSingleton<LessorService>();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddSingleton<BoatService>();
builder.Services.AddSingleton<BookingService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        configurePolicy =>
        {
            configurePolicy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
BsonSerializer.RegisterIdGenerator(typeof(string), new StringObjectIdGenerator());
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
