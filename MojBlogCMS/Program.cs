using Microsoft.EntityFrameworkCore;
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var options = new DbContextOptionsBuilder<BlogDbContext>()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .Options;

builder.Services.AddSingleton(BlogDbContextSingleton.GetInstance(options));

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