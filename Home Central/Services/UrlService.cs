using Home_Central.Data;
using HomeCentral.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace HomeCentral.Services;

public class UrlService : IUrlService
{
    private readonly HomeDbContext dbContext;
    public UrlService(HomeDbContext db)
    {
        this.dbContext = db;
    }

    public async Task Delete(Linken url)
    {
        dbContext.Linken.Remove(url);
        await dbContext.SaveChangesAsync(); 
    }

    public async Task Delete(int id)
    {
        try { 
            var r = dbContext.Linken.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Linken.Remove(r);
        } catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Linken>> GetURLAsync()
    {
        var list = await dbContext.Linken.ToListAsync();
        return list;
    }

    public async Task<Linken?> GetUrlAsync(int Id)
    {
        var item = await dbContext.Linken.Where(x => x.Id == Id).FirstOrDefaultAsync();
        return item;
    }

    public async Task Post(Linken url)
    {
        var item = await dbContext.Linken.AddAsync(url);
        var resultaat = await dbContext.SaveChangesAsync();        
    }

    public async Task Update(Linken url)
    {
        var item = await dbContext.Linken.AddAsync(url);
        var resultaat = await dbContext.SaveChangesAsync();
    }
}
