using dvcsa.Models;
using Microsoft.EntityFrameworkCore;

namespace dvcsa.Db;

public class GenericContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public static string DbPath { get; private set; }
    
    public GenericContext(DbContextOptions<GenericContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        Database.EnsureCreated();
        DbPath = System.IO.Path.Join(path, "dvcsa.db");
    }
    
    public static string GetConnectionString()
    {
        if (DbPath == "")
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "dvcsa.db");
        }
        return $"Data Source={DbPath}";
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "admin",
                Password = "admin"
            }
        );
    }
}