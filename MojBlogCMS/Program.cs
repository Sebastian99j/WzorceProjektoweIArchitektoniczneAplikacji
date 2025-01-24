using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MojBlogCMS.Repositories;
using MojBlogCMS.Data;
using MojBlogCMS.Facade;
using MojBlogCMS.Factory;
using MojBlogCMS.Decorator;
using MojBlogCMS.Models;
using MojBlogCMS.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var options = new DbContextOptionsBuilder<BlogDbContext>()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .Options;

builder.Services.AddSingleton(BlogDbContextSingleton.GetInstance(options));
builder.Services.AddSingleton<JwtService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
builder.Services.AddScoped<IPostFacade, PostFacade>();
builder.Services.AddScoped<IPostFactory<IPost>, PostFactory>();

builder.Services.AddScoped(typeof(ValidationManager<>));
builder.Services.AddScoped<IValidationStrategy<Post>, PostValidationStrategy>();
builder.Services.AddScoped<IValidationStrategy<Post>, TitleLengthValidationStrategy>();
builder.Services.AddScoped<IValidationStrategy<Post>, KeywordValidationStrategy>();

builder.Services.AddScoped<EfCoreRepository<Post>>();
builder.Services.AddScoped<IRepository<Post>>(provider =>
{
    var innerRepo = provider.GetRequiredService<EfCoreRepository<Post>>();
    return new LoggingRepositoryDecorator<Post>(innerRepo);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine($"Token validated for user: {context.Principal.Identity.Name}");
                return Task.CompletedTask;
            },
            OnMessageReceived = context =>
            {
                Console.WriteLine($"Token received: {context.Token}");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                Console.WriteLine("Token challenge triggered.");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("Authorization"))
    {
        string authHeader = context.Request.Headers["Authorization"];
        Console.WriteLine($"Authorization Header: {authHeader}");

        if (authHeader.StartsWith("Bearer "))
        {
            var token = authHeader.Substring("Bearer ".Length).Trim();
            Console.WriteLine($"Extracted Token: {token}");
        }
        else
        {
            Console.WriteLine("Authorization Header is not in the correct format.");
        }
    }
    else
    {
        Console.WriteLine("Authorization Header is missing.");
    }

    await next();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();