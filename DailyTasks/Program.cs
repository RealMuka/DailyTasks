using DailyTasks.DataBase;
using DailyTasks.DataBase.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<TaskRepository>();

builder.Services
	.AddDbContext<MainDbContext>(c =>
	{
		c.UseNpgsql(config.GetConnectionString("MainDbContext"));
	});

var app = builder.Build();

app.UseFastEndpoints();

app.UseSwaggerGen();
app.UseOpenApi();

app.Run();
