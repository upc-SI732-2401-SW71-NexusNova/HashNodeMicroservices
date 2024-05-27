using FinancialOperations.Payment.Application.Services;
using FinancialOperations.Payment.Domain.Repositories;
using FinancialOperations.Payment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "HashDev API Rest", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PaymentDbContext>(options =>
{
    options.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
//using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
//{
//    context.Database.EnsureCreated();
//}

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();