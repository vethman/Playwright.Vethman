using Playwright.Vethman.UiTests.Services;

namespace Playwright.Vethman.UiTests.PageObjects;

public class LoginPage
{
    private readonly IPage _page;
    private readonly UrlService _urlService;

    public LoginPage(IPage page, UrlService urlService)
    {
        _page = page;
        _urlService = urlService;
    }

    private ILocator Email => _page.Locator("input[data-testid='Email.field.fancy-text-field']");
    private ILocator Password => _page.Locator("input[data-testid='Password.field.fancy-text-field']");
    private ILocator LoginButton => _page.Locator("button[data-testid='login.button']");
    private ILocator KeepMeLoggedinButton => _page.Locator("label[data-testid='Login.KeepMeLoggedInSwitch.wrapper']");
    private ILocator LoginErrorTitle => _page.Locator("h2[data-testid='login-failed-error-notification.title']");
    private ILocator LoginErrorTitleCloseButton => _page.Locator("div[data-testid='login-failed-error-notification.close-button']");

    public async Task OpenAsync()
    {
        await _urlService.NavigateToAsync("login");
    }

    public async Task LoginAsync()
    {
        await Email.FillAsync(TestContext.Parameters.Get("Email")!);
        await Password.FillAsync(TestContext.Parameters.Get("Password")!);
        await LoginButton.ClickAsync();

        if (await HasLoginErrorAsync())
        {
            await LoginButton.ClickAsync();
        }
    }

    private async Task<bool> HasLoginErrorAsync()
    {
        try
        {
            await LoginErrorTitle.WaitForAsync(new LocatorWaitForOptions
            {
                Timeout = 500
            });

            await LoginErrorTitleCloseButton.ClickAsync();

            return true;
        }
        catch { return false; }
    }
}
