using HackerNewsAPI.Model;
using HackerNewsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HackerNewsController : Controller
{
    private readonly IHackerNewsService _hackerNewsService;

    public HackerNewsController(IHackerNewsService hackerNewsService)
    {
        _hackerNewsService = hackerNewsService;
    }

    [HttpGet("hackers-news")]
    public async Task<ActionResult<List<HackerNewsItem>>> GetHackersNews()
    {
        var items = await _hackerNewsService.GetHackerNewsItemsAsync();
        return Ok(items);
    }

    [HttpGet("hacker-news-ids")]
    public async Task<ActionResult<List<HackerNewsItem>>> GetHackerNewsIds()
    {
        List<int> items = await _hackerNewsService.GetHackerNewsIdsAsync();
        return Ok(items);
    }

    [HttpGet("hacker-news-detail/{id}")]
    public async Task<ActionResult<List<HackerNewsItem>>> GetHackerNewsDatail(int id)
    {
        var newsDetail = await _hackerNewsService.GetHackerNewsItemsByIdsAsync(id);
        return Ok(newsDetail);
    }
}
