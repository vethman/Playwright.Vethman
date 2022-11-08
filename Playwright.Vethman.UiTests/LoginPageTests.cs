using Playwright.Vethman.UiTests.PageObjects;

namespace Playwright.Vethman.UiTests
{
    public class LoginPageTests : TestStartup
    {
        private LoginPage _loginPage;

        [SetUp]
        public async Task Setup()
        {
            _loginPage = GetService<LoginPage>();
            await _loginPage.OpenAsync();
        }

        //Sometimes there will be a captcha, please run again or set a breakpoint to help clicking the pictures =D
        //If you want te renew the storagestate please first delete state.json before running test
        [Test]
        [Ignore("Only run when no storagestate or to renew storagestate")]
        public async Task LoginAndSaveState()
        {
            await _loginPage.OpenAsync();
            await _loginPage.LoginAsync();

            //If there is a captcha you have 30 seconds to complete and press Login again manually, slowpokes can
            await Page.WaitForURLAsync(TestContext.Parameters.Get("BaseUrl")!, new PageWaitForURLOptions { Timeout = 30000 });

            await Page.Context.StorageStateAsync(new()
            {
                Path = "state.json"
            });
        }
    }
}
