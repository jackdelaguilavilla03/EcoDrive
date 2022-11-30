using EcoDriver.API.Loyalty.Domain.Repositories;
using EcoDriver.API.Loyalty.Domain.Services;
using EcoDriver.API.Loyalty.Persistence.Repositories;
using EcoDriver.API.Loyalty.Services;
using EcoDriver.API.Shared.Domain.Repositories;
using EcoDriver.API.Shared.Persistence.Context;
using EcoDriver.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<IRewardService, RewardService>();

builder.Services.AddAutoMapper(
    typeof(EcoDriver.API.Loyalty.Mapping.ModelToResourceProfile),
    typeof(EcoDriver.API.Loyalty.Mapping.ResourceToModelProfile));


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EcoDriver.API.Rewards",
        Description = "EcoDriver.API.Rewards",
        Contact = new OpenApiContact
        {
            Name = "Andy Jack Del Aguila Villanueva",
            Email = "u20201a963@upc.edu.pe",
            Url = new Uri("https://www.example.com")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope()) 
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json","EcoDriver.API.Rewards");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();