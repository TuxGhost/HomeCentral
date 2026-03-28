using Microsoft.EntityFrameworkCore.Design;
using HomeCentral.Data;
using HomeCentral.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeCentral.Data;

public class HomeDbContextUpdateFactory : IDesignTimeDbContextFactory<HomeDbContextUpdate>
{
    public HomeDbContextUpdate CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HomeDbContextUpdate>();
        Console.WriteLine("Enter the connection string for the database:"); 
        string connectionString = Console.ReadLine()??"";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new HomeDbContextUpdate(optionsBuilder.Options);

    }
}
