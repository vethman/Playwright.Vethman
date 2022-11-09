using Playwright.Vethman.UiTests.Services;

namespace Playwright.Vethman.UiTests;

[Parallelizable(ParallelScope.Self)]
public class Tests : TestStartup
{
    private UrlService _urlService;

    [SetUp]
    public async Task Setup()
    {
        _urlService = GetService<UrlService>();
        await _urlService.NavigateToAsync();
    }

    [Test]
    public async Task NoError_CompletesTestrunFast()
    {
        await Expect(Page).ToHaveURLAsync(TestContext.Parameters.Get("BaseUrl")!);
    }

    // Change headless value in test.runsettings to see the effect
    [Test]
    public async Task Error_HeadedCompletesTestrunSlow_HeadlessIsFast()
    {
        await Expect(Page).ToHaveURLAsync(TestContext.Parameters.Get("BaseUrl")!);

        Assert.That(true, Is.EqualTo(false));
    }
}