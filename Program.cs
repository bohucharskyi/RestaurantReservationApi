using Microsoft.EntityFrameworkCore;
using ReservationApi.Models;
using ReservationApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RestaurantReservationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

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