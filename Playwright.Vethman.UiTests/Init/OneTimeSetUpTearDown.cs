using Playwright.Vethman.UiTests.Init;

[SetUpFixture]
public class OneTimeSetUpTearDown
{
    [OneTimeSetUp]
    public static async Task Init()
    {
        if (!File.Exists("state.json") && File.GetCreationTime("state.json") < DateTime.Now.AddDays(-1))
        {
            var loginOnce = new LoginOnce();
            await loginOnce.LoginAndSaveState();
        }; 
    }
}
