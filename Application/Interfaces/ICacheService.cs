namespace Application.Interfaces;

public interface ICacheService
{
    public Task SetAsync(long key, string value);
    public Task<string?> GetAsync(long key);
    public Task RemoveAsync(long key);
}