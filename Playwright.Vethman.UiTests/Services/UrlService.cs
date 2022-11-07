namespace Playwright.Vethman.UiTests.Services;

public class UrlService
{
    private readonly IPage _page;
    private readonly string _baseUrl;

    public UrlService(IPage page)
    {
        _page = page;
        _baseUrl = TestContext.Parameters.Get("BaseUrl")!;
    }

    public async Task NavigateToAsync(string urlExtension = "")
    {
        await _page.GotoAsync(Path.Combine(_baseUrl, urlExtension), new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
    }
}
