using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using mission10.Data;

var builder = WebApplication.CreateBuilder(args);
SQLitePCL.Batteries_V2.Init();

var dbPath = Path.Combine(builder.Environment.ContentRootPath, "BowlingLeague.sqlite");
var baseConnectionString = builder.Configuration.GetConnectionString("SqliteConnection")
    ?? throw new InvalidOperationException("Missing connection string 'SqliteConnection'.");
var connectionBuilder = new SqliteConnectionStringBuilder(baseConnectionString)
{
    DataSource = dbPath
};


builder.Services.AddControllers();

builder.Services.AddDbContext<BowlerDbContext>(options =>
    options.UseSqlite(connectionBuilder.ConnectionString));

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
