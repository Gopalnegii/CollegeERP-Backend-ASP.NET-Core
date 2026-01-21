using CollegeERP_.API.Middleware;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;
using CollegeERP_.Application.Services;
using CollegeERP_.Infrastructure.Data.Context;
using CollegeERP_.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add services to the container.

builder.Services.AddDbContext<CollegeERPDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeERP")));
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>(); //Global Exception handler

app.MapControllers();

app.Run();
