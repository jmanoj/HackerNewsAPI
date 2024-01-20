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

    [HttpGet]
    public async Task<ActionResult<List<HackerNewsItem>>> GetCombinedData()
    {
        var items = await _hackerNewsService.GetHackerNewsItemsAsync();
        return Ok(items);
    }
}
