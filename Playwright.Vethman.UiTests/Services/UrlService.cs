namespace Playwright.Vethman.UiTests.Services;

public class UrlService
{
    private readonly IPage _page;
    private readonly string _baseUrl;

    public UrlService(IPage page, string baseUrl)
    {
        _page = page;
        _baseUrl = baseUrl;
    }

    public async Task NavigateToAsync(string urlExtension = "")
    {
        await _page.GotoAsync(Path.Combine(_baseUrl, urlExtension), new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
    }
}
