using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using tasky.DataAccess;

var builder = WebApplication.CreateBuilder(args);


//1.Add context to builder services

builder.Services.AddDbContext<TaskyDBContext>(options => options.UseMySql("server=myshoulder.cdvg9i8dvcl6.eu-west-3.rds.amazonaws.com;port=3306;user=ComboWombo;password=ComboWombo123!;database=TaskyServer;AllowZeroDateTime=True",
                ServerVersion.AutoDetect("server=myshoulder.cdvg9i8dvcl6.eu-west-3.rds.amazonaws.com;port=3306;user=ComboWombo;password=ComboWombo123!;database=TaskyServer;AllowZeroDateTime=True")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
