using HackerNewsAPI.Constants;
using HackerNewsAPI.Model;
using HackerNewsAPI.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;

public class HackerNewsService : IHackerNewsService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public HackerNewsService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClient;
        _baseUrl = apiSettings.Value.BaseUrl!;
    }

    public async Task<List<HackerNewsItem>> GetHackerNewsItemsAsync()
    {
        List<int> storiesIds = await GetHackerNewsIdsAsync();
        var hackerNews = storiesIds.Take(200).Select(id => GetHackerNewsItemsByIdsAsync(id));
        HackerNewsItem[] hackerNewsItems = await Task.WhenAll(hackerNews);
        return hackerNewsItems.ToList();
    }

    public async Task<List<int>> GetHackerNewsIdsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + Endpoints.AskStories);

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<int> askStoriesResponse = JsonSerializer.Deserialize<List<int>>(jsonResponse)!;
            return askStoriesResponse;
        }
        else
        {
            return new List<int>();
        }
    }

    public async Task<HackerNewsItem> GetHackerNewsItemsByIdsAsync(int itemId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}item/{itemId}.json");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            HackerNewsItem combinedResponse = JsonSerializer.Deserialize<HackerNewsItem>(jsonResponse)!;
            return combinedResponse;
        }
        else
        {
            return new HackerNewsItem();
        }
    }
}
