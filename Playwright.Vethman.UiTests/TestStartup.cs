using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Interfaces;
using Playwright.Vethman.UiTests.Services;

namespace Playwright.Vethman.UiTests;

public class TestStartup : PageTest
{
    private readonly IServiceProvider _serviceProvider;

    private static string BaseUrl => TestContext.Parameters.Get("BaseUrl")!;

    public TestStartup()
    {
        _serviceProvider = BuildServices();
    }

    public T GetService<T>() where T : notnull => _serviceProvider.GetRequiredService<T>();

    public override BrowserNewContextOptions ContextOptions()
    {
        var browserNewContextOptions = new BrowserNewContextOptions()
        {
            ColorScheme = ColorScheme.Dark,
            BaseURL = BaseUrl,
            ScreenSize = new ScreenSize() { Width = 1920, Height = 1080 }
        };

        return browserNewContextOptions;
    }

    private IServiceProvider BuildServices()
    {
        var services = new ServiceCollection();

        services.AddTransient(_ => Page);
        services.AddTransient(_ => new UrlService(Page));

        var pageObjects = typeof(TestStartup).Assembly.GetTypes()
            .Where(s => s.FullName!.Contains(".PageObjects.") && s.IsInterface == false);

        foreach (var pageObject in pageObjects)
        {
            services.AddTransient(pageObject);
        }

        return services.BuildServiceProvider();
    }
}
