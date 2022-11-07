namespace Playwright.Vethman.UiTests.PageObjects.Components;

public class HeaderComponent
{
    private readonly IPage _page;

    public HeaderComponent(IPage page)
    {
        _page = page;
    }

    public ILocator CustomerTitle => _page.Locator("p[data-testid='customer-account.title']");
    public ILocator LoginTitle => _page.Locator("p[data-testid='log-in.title']");

    private ILocator Customer => _page.Locator("div[data-testid='customer-account']");
    private ILocator Login => _page.Locator("div[data-testid='log-in']");
    private ILocator LogoutButton => _page.Locator("li[data-testid='logout.button']");

    public async Task NavigateToLoginAsync()
    {
        await Login.ClickAsync();
    }

    public async Task LogoutAsync()
    {
        await Customer.ClickAsync();
        await LogoutButton.ClickAsync();
    }
}
