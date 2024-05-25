using HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "HashDev API Rest", Version = "v1" });
    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ModelToResourceProfile)
);
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

public partial class Program { }