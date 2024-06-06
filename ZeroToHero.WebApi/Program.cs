using Microsoft.EntityFrameworkCore;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Application.Common.Helpers;
using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Data.Repositories;
using Application.Services;
using ZeroToHero.Application.Services;
using ZeroToHero.Application.Common.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Unit Of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWrok>();

// Services
builder.Services.AddTransient<IResumeService, ResumeService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IAuthManager, AuthManager>();


//---> Mappers
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Services.GetService<IHttpContextAccessor>() is not null)
{
    HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();