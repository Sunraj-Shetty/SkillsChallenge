using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<PersonContext>(opt => opt.UseInMemoryDatabase("People"));
builder.Services.AddDbContext<PlaceContext>(opt => opt.UseInMemoryDatabase("Places"));
builder.Services.AddDbContext<ThingContext>(opt => opt.UseInMemoryDatabase("Things"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure ApiBehaviorOptions
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressMapClientErrors = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
