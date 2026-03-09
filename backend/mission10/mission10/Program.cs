using Microsoft.EntityFrameworkCore;
using mission10.Data;

var builder = WebApplication.CreateBuilder(args);
SQLitePCL.Batteries_V2.Init();


builder.Services.AddControllers();

builder.Services.AddDbContext<BowlerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowViteDev",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowViteDev");

app.MapControllers();

app.Run();