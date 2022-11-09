using Playwright.Vethman.UiTests.Services;

namespace Playwright.Vethman.UiTests.PageObjects;

public class OverviewPage
{
    private readonly IPage _page;
    private readonly UrlService _urlService;

    public OverviewPage(IPage page, UrlService urlService)
    {
        _page = page;
        _urlService = urlService;
    }

    public async Task OpenAsync()
    {
        await _urlService.NavigateToAsync();
    }
}