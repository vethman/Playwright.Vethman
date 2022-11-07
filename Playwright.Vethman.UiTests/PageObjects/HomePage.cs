namespace Playwright.Vethman.UiTests.PageObjects;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public ILocator Customer => _page.Locator("p[data-testid='customer-account.title']");
    
    private ILocator Delivery => _page.Locator("button[data-testid='DeliveryServiceSelection']");

    public async Task StartDeliveryOrderAsync()
    {
        await Delivery.ClickAsync();
    }
}