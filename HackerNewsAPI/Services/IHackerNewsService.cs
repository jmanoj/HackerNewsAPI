using HackerNewsAPI.Model;

namespace HackerNewsAPI.Services;

public interface IHackerNewsService
{
    Task<List<HackerNewsItem>> GetHackerNewsItemsAsync();
}
