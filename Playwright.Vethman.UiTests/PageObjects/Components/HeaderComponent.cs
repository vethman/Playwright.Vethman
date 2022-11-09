namespace Playwright.Vethman.UiTests.PageObjects.Components;

public class HeaderComponent
{
    private readonly IPage _page;

    public HeaderComponent(IPage page)
    {
        _page = page;
    }

    private ILocator Component => _page.Locator(".Layout-main nav").First;
    private ILocator Overview => Component.Locator("a:has-text(\"Overview\")");
    private ILocator Repositories => Component.Locator("a:has-text(\"Repositories\")");

    public Task NavigateToOverviewAsync()
    {
        return Overview.ClickAsync();
    }

    public Task NavigateToRepositoriesAsync()
    {
        return Repositories.ClickAsync();
    }
}
