using HomeCentral.Data.Entities;
namespace HomeCentral.Services;

public interface IUrlService
{    
    public Task<IEnumerable<Linken>> GetURLAsync();
    public Task<Linken?> GetUrlAsync(int Id);
    public Task Post(Linken url);
    public Task Update(Linken url);
    public Task Delete(Linken url);
    public Task Delete(int id);

}


