using Sailboat_Rental.Models;
using SailBoat_Rental.Services;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<StoreSailboatDatabaseSetting>(builder.Configuration.GetSection("StoreSailboatDatabaseSetting"));
builder.Services.AddSingleton<CategoryService>();
//builder.Services.Configure<StoreSailboatDatabaseSetting>(builder.Configuration.GetSection("StoreSailboatDatabaseSetting1"));
builder.Services.AddSingleton<LessorServices>();
//builder.Services.Configure<StoreSailboatDatabaseSetting>(builder.Configuration.GetSection(nameof(StoreSailboatDatabaseSetting)));
//builder.Services.AddSingleton<StoreSailboatDatabaseSetting>(sp=>sp.GetRequiredService<IOptions<StoreSailboatDatabaseSetting>>().Value);
//builder.Services.AddSingleton<IMongoClient>(s =>

//new MongoClient(builder.Configuration.GetValue<string>("StoreSailboatDatabaseSetting:ConnectionString")));
//builder.Services.AddScoped<ICategoryService, CategoryService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
