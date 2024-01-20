using HackerNewsAPI.Model;
using Microsoft.Extensions.Options;
using Moq;

namespace HackerNewAPITest;

[TestClass]
public class HackerNewsServiceUnitTest
{
    private HackerNewsService _hackerNewsService = null!;
    private Mock<IOptions<ApiSettings>> _apiSettingsMock = null!;
    private Mock<HttpClient> _httpClientMock = null!;

    [TestInitialize]
    public void Initialize()
    {
        _apiSettingsMock = new Mock<IOptions<ApiSettings>>();
        _httpClientMock = new Mock<HttpClient>();
    }

    [TestMethod]
    public async Task GetHackerNewsItemsAsync_SuccessAsync()
    {
        // Arrange
        ApiSettings apiSettings = new ApiSettings() { BaseUrl = "https://hacker-news.firebaseio.com/v0/" };

        _apiSettingsMock.Setup(x => x.Value).Returns(apiSettings);
        _hackerNewsService = new HackerNewsService(_httpClientMock.Object, _apiSettingsMock.Object);

        // Act
        var result = await _hackerNewsService.GetHackerNewsItemsAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count > 0);
    }

}