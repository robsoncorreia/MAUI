using Maui.Infrastructure.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionStrings = builder.Configuration["ConnectionStrings"];

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MauiContext>(options =>
{
    _ = options.UseSqlServer(connectionStrings);
    //_ = options.UseInMemoryDatabase(Guid.NewGuid().ToString());
});

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