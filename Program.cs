using System.Data.Common;
using System.Text.Encodings.Web;
using dvcsa.Db;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Add db context
builder.Services.AddSingleton<DbConnection, SqliteConnection>(serviceProvider =>
{
    var connection = new SqliteConnection(GenericContext.GetConnectionString());
    connection.Open();
    return connection;
});

builder.Services.AddDbContext<GenericContext>((serviceProvider, options) =>
{
    var connection = serviceProvider.GetRequiredService<DbConnection>();
    options.UseSqlite(connection);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://0.0.0.0:9000");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
