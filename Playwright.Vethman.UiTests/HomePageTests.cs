using Playwright.Vethman.UiTests.PageObjects.Components;
using Playwright.Vethman.UiTests.Services;

namespace Playwright.Vethman.UiTests;

[Parallelizable(ParallelScope.Self)]
public class HomePageTests : TestStartup
{
    private HeaderComponent _headerComponent;
    private UrlService _urlService;

    [SetUp]
    public async Task Setup()
    {
        _headerComponent = GetService<HeaderComponent>();
        _urlService = GetService<UrlService>();
        await _urlService.NavigateToAsync();
    }

    [Test]
    public async Task HomePage_ShouldHaveCorrectTitle()
    {
        await Expect(Page).ToHaveURLAsync(TestContext.Parameters.Get("BaseUrl")!);
        await Expect(Page).ToHaveTitleAsync("Domino's Online Ordering");
    }

    [Test]
    public async Task HomePage_ShouldShowLoggedInUser()
    {
        await Expect(_headerComponent.CustomerTitle).ToContainTextAsync(TestContext.Parameters.Get("Username")!);
    }

    [Test]
    public async Task HomePage_Logout_ShouldLogout()
    {
        await _headerComponent.LogoutAsync();

        await Expect(_headerComponent.CustomerTitle).ToBeHiddenAsync();
        await Expect(_headerComponent.LoginTitle).ToContainTextAsync("Log In");
    }
}