using Home_Central.Data;
using Home_Central.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home_Central.Services;

public class HomeService : IHomeService
{
    private readonly HomeDbContext context;
    public HomeService(HomeDbContext context) 
    {
        this.context = context;
    }

    public async Task DeleteHomeText(HomeText text)
    {
        context.Remove(text);
        await context.SaveChangesAsync();   
    }

    public async Task<HomeText?> GetHomeTextAsync(int Id)
    {
        var result = await context.HomeTexts.FindAsync(Id);
        return result;
    }

    public async Task<IEnumerable<HomeText>> GetHomeTextsAsync()
    {
        var result = await context.HomeTexts.ToListAsync();
        return result;
    }

    public async Task PostHomeText(HomeText text)
    {
        context.Add(text);
        await context.SaveChangesAsync();
    }

    public async Task UpdateHomeText(HomeText text)
    {
        context.Update(text);
        await context.SaveChangesAsync();
    }
}
