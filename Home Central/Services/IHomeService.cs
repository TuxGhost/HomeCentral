using Home_Central.Data.Entities;

namespace Home_Central.Services;

public interface IHomeService
{
    public Task<IEnumerable<HomeText>> GetHomeTextsAsync();
    public Task<HomeText?> GetHomeTextAsync(int Id);
    public Task PostHomeText(HomeText text);
    public Task UpdateHomeText(HomeText text);
    public Task DeleteHomeText(HomeText text);


}
