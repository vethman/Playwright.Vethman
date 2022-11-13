namespace Playwright.Vethman.UiTests;

[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{
    // Set channel to msedge to have a slow shutdown, only in headed mode. Headless is fast.
    [Test]
    public async Task SlowTestRunShutDownWhenTestFails()
    {
        Assert.Fail();
    }

    [Test]
    public async Task FastTestRunShutDownWhenTestSucceeds()
    {
        Assert.True(true);
    }
}