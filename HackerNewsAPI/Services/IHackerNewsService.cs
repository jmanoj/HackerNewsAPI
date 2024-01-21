using HackerNewsAPI.Model;

namespace HackerNewsAPI.Services;

public interface IHackerNewsService
{
    Task<List<HackerNewsItem>> GetHackerNewsItemsAsync();
    Task<List<int>> GetHackerNewsIdsAsync();
    Task<HackerNewsItem> GetHackerNewsItemsByIdsAsync(int itemId);
}
