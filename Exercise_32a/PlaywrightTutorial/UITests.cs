using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

[TestClass]
public class UITests : PageTest
{
    [TestMethod]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }

    [Ignore]
    [TestMethod]
    public async Task TestingToPlanTripAtSL()
    {
        Console.WriteLine($"HEADED: {Environment.GetEnvironmentVariable("HEADED")}");

        await Page.GotoAsync("https://sl.se");

        Playwright.Selectors.SetTestIdAttribute("data-test-id");

        // Choose origin
        await Page.GetByTestId("journey-planner-origin-wrapper").GetByTestId("typeahead-input").FillAsync("Gärdet");
        await Page.Locator("#journey-planner-typeahead-origin-result-0").ClickAsync();

        // Choose destination
        await Page.GetByTestId("journey-planner-destination-wrapper").GetByTestId("typeahead-input").FillAsync("Gamla Stan");
        await Page.Locator("#journey-planner-typeahead-destination-result-0").ClickAsync();

        // Search
        await Page.GetByTestId("journey-planner-submit-wrapper").GetByTestId("button").ClickAsync();

        // Open first search result
        await Page.GetByTestId("journey-heading").First.ClickAsync();

        // Assert
        await Expect(Page.GetByText("Prisinformation och enkelbiljetter")).ToBeVisibleAsync();
    }
}