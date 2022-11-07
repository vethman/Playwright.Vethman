using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Interfaces;
using Playwright.Vethman.UiTests.Services;

namespace Playwright.Vethman.UiTests;

public class TestStartup : PageTest
{
    private readonly IServiceProvider _serviceProvider;

    private string BaseUrl => TestContext.Parameters.Get("BaseUrl")!;

    [SetUp]
    public async Task SetupStartupAsync()
    {
        Context.SetDefaultTimeout(TestContext.Parameters.Get("DefaultTimeout", 10000));

        if (TestContext.Parameters.Get("Tracing", false))
        {
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }
    }

    [TearDown]
    public async Task TearDownStartupAsync()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var path = $"Tracing/{TestContext.CurrentContext.Test.FullName}_{DateTime.Now:yyyyMMddHHmmssss}.zip";

            await Context.Tracing.StopAsync(new()
            {
                Path = path
            });

            TestContext.AddTestAttachment(path);
        }
    }

    public TestStartup()
    {
        _serviceProvider = BuildServices();
    }

    public T GetService<T>() where T : notnull => _serviceProvider.GetRequiredService<T>();

    public override BrowserNewContextOptions ContextOptions()
    {
        var stateFileExists = File.Exists("state.json");

        var browserNewContextOptions = new BrowserNewContextOptions()
        {
            ColorScheme = ColorScheme.Light,
            BaseURL = BaseUrl,
            ScreenSize = new ScreenSize() { Width = 1920, Height = 1080 },
            StorageStatePath = stateFileExists ? "state.json" : null
        };

        return browserNewContextOptions;
    }

    private IServiceProvider BuildServices()
    {
        var services = new ServiceCollection();

        services.AddTransient(_ => Page);
        services.AddTransient(_ => new UrlService(Page, BaseUrl));

        var pageObjects = typeof(TestStartup).Assembly.GetTypes()
            .Where(s => s.FullName!.Contains(".PageObjects.") && s.IsInterface == false);

        foreach (var pageObject in pageObjects)
        {
            services.AddTransient(pageObject);
        }

        return services.BuildServiceProvider();
    }
}
