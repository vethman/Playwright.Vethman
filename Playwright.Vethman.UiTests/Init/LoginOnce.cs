using Playwright.Vethman.UiTests.PageObjects;

namespace Playwright.Vethman.UiTests.Init;

public class LoginOnce : TestStartup
{
    private readonly LoginPage _loginPage;

    public LoginOnce()
    {
        _loginPage = GetService<LoginPage>();
    }

    public async Task LoginAndSaveState()
    {
        await _loginPage.OpenAsync();
        await _loginPage.LoginAsync();

        await Page.WaitForURLAsync(TestContext.Parameters.Get("BaseUrl")!);

        await Page.Context.StorageStateAsync(new()
        {
            Path = "state.json"
        });

        await Browser.DisposeAsync();
    }
}
