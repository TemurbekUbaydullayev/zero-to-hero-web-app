using Microsoft.EntityFrameworkCore;

using ZeroToHero.Application.Interfaces;

using ZeroToHero.Application.Common.Helpers;

using ZeroToHero.Data.DbContexts;

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

builder.Services.AddTransient<IEmailService, IEmailService>();

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