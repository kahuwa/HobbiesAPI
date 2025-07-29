using HobbiesAPI.Data;
using Microsoft.EntityFrameworkCore;
using HobbiesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using HobbiesAPI.Repositories;
using HobbiesAPI.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IHobbiesService, HobbiesService>();
builder.Services.AddScoped<IHobbiesRepository, HobbiesAPI.Repositories.HobbiesRepository>();
var app = builder.Build();

    
    
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class HobbiesController : ControllerBase

{
    private readonly IHobbiesService _hobbiesService;

    public HobbiesController(IHobbiesService hobbiesService)
    {
        _hobbiesService = hobbiesService;
    }

   
}

