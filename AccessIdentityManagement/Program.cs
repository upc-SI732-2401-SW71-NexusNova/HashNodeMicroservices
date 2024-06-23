using HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices.Factories;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices.Facades;
using HashNode.API.AccessIdentityManagement.Domain.Repositories;
using HashNode.API.AccessIdentityManagement.Domain.Services;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
using HashNode.API.AccessIdentityManagement.infrastructure.Persistence.Repositories;
using HashNode.API.AccessIdentityManagement.Presentation.Rest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IUserCommandService, UserCommandServiceImpl>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddScoped<IUserQueryService, UserQueryServiceImpl>();
builder.Services.AddScoped<IUserFacade, UserFacade>();

builder.Services.AddScoped<IProfileService, ProfileServiceImpl>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandServiceImpl>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileFactory, ProfileFactory>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryServiceImpl>();
builder.Services.AddScoped<IProfileFacade, ProfileFacade>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "HashDev API Rest", Version = "v1" });
    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString, option => option.EnableRetryOnFailure())
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ModelToResourceProfile),
    typeof(ResourceToCommandProfile),
    typeof(ResponseToResourceProfile)
);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }