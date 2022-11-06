using Maui.Infrastructure.Configuration.SqlServer;
using Maui.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MauiContext>(options =>
    options.UseSqlServer(UriHelper.GetConfig() ?? throw new InvalidOperationException("Connection string 'MauiWebApplication' not found.")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();