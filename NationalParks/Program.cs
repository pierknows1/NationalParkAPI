using NationalParks.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
     
});

builder.Services.AddDbContext<ParksApiContext>(dbContextOptions =>
{
    dbContextOptions.UseMySql(builder.Configuration["ConnectionStrings:DefaultConnection"],
        ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    
    app.UseHttpsRedirection();
}

app.UseCors();
app.MapControllers();

app.Run();
