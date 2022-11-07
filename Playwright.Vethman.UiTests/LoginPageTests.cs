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

        //Sometimes there will be a captcha, please run again or use SlowMo to help clicking the pictures =D
        [Test]
        [Ignore("Only run when no storagestate or to renew storagestate")]
        public async Task LoginAndSaveState()
        {
            await _loginPage.OpenAsync();
            await _loginPage.LoginAsync();

            await Page.WaitForURLAsync(TestContext.Parameters.Get("BaseUrl")!);

            await Page.Context.StorageStateAsync(new()
            {
                Path = "state.json"
            });
        }
    }
}
