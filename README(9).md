# C# SpecFlow Web UI Automation

[![Language](https://img.shields.io/badge/language-C%23-blue)](https://learn.microsoft.com/dotnet/csharp/)
[![Selenium](https://img.shields.io/badge/Selenium-WebDriver-43B02A)](https://www.selenium.dev/)
[![BDD](https://img.shields.io/badge/BDD-Gherkin-orange)](https://cucumber.io/docs/gherkin/)
[![Framework](https://img.shields.io/badge/framework-SpecFlow-purple)](https://specflow.org/)

A maintainable **C# Web UI automation framework** demonstrating **Behavior Driven Development (BDD)** with **SpecFlow/Gherkin**, **Selenium WebDriver**, and a structured **Page Object Model (POM)** approach.

> Repository: https://github.com/vinodkpasi/csharp-specflow-web-ui-automation

---

## 📌 Table of Contents

- [Overview](#-overview)
- [Key Features](#-key-features)
- [Technology Stack](#-technology-stack)
- [BDD Architecture](#-bdd-architecture)
- [Project Structure](#-project-structure)
- [How the Framework Works](#-how-the-framework-works)
- [Gherkin and SpecFlow](#-gherkin-and-specflow)
- [Feature Files](#-feature-files)
- [Step Definitions](#-step-definitions)
- [Page Object Model](#-page-object-model)
- [Browser Lifecycle](#-browser-lifecycle)
- [Hooks](#-hooks)
- [Synchronization and Waits](#-synchronization-and-waits)
- [Test Data](#-test-data)
- [Configuration](#-configuration)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Build](#-build)
- [Run Tests](#-run-tests)
- [Run Tests by Tag](#-run-tests-by-tag)
- [Visual Studio Execution](#-visual-studio-execution)
- [Command-Line Execution](#-command-line-execution)
- [Debugging](#-debugging)
- [Reporting](#-reporting)
- [Screenshots on Failure](#-screenshots-on-failure)
- [Parallel Execution](#-parallel-execution)
- [CI/CD](#-cicd)
- [Cross-Browser Execution](#-cross-browser-execution)
- [Best Practices](#-best-practices)
- [Troubleshooting](#-troubleshooting)
- [Recommended Enhancements](#-recommended-enhancements)
- [SpecFlow and Reqnroll Note](#-specflow-and-reqnroll-note)
- [Contributing](#-contributing)
- [Author](#-author)

---

## 🎯 Overview

This project demonstrates a typical end-to-end BDD automation flow:

```text
Business Requirement
        │
        ▼
Gherkin Feature
        │
        ▼
SpecFlow Scenario
        │
        ▼
Step Definitions
        │
        ▼
Page Objects
        │
        ▼
Selenium WebDriver
        │
        ▼
Web Browser
        │
        ▼
Application Under Test
```

The framework keeps the **business-readable test specification** separate from the **technical browser implementation**.

This structure is useful when:

- Product owners or business analysts define acceptance criteria.
- QA engineers write or review Gherkin scenarios.
- Automation engineers implement step definitions.
- Page objects encapsulate Selenium interactions.
- NUnit/test infrastructure executes scenarios.

---

# ✨ Key Features

### BDD with Gherkin

Tests can be expressed using:

```text
Feature
Scenario
Given
When
Then
And
But
Scenario Outline
Examples
Tags
```

Example:

```gherkin
Feature: Web application search

  Scenario: Search using a valid keyword
    Given I navigate to the application
    When I enter "automation" in the search field
    And I click the search button
    Then the search results should be displayed
```

### Selenium Web UI Automation

Selenium WebDriver can automate:

- Navigation
- Clicking
- Text entry
- Dropdowns
- Checkboxes
- Radio buttons
- Browser navigation
- Element validation
- Page-state validation

### Page Object Model

UI locators and page-specific actions are encapsulated inside page classes rather than being scattered throughout step definitions.

### SpecFlow Hooks

Hooks can control the test lifecycle:

```text
BeforeTestRun
BeforeFeature
BeforeScenario
BeforeStep
AfterStep
AfterScenario
AfterFeature
AfterTestRun
```

### Reusable Step Definitions

Well-designed steps can be reused by multiple scenarios and feature files.

### NUnit Integration

The framework can use NUnit as the underlying test execution framework, depending on the project's configured test packages.

### Explicit Synchronization

Explicit waits can synchronize automation with dynamically rendered web applications.

### CI/CD Ready

The framework can be integrated into:

- GitHub Actions
- Azure DevOps
- Jenkins
- GitLab CI/CD

---

# 🧰 Technology Stack

| Technology | Purpose |
|---|---|
| **C#** | Automation programming language |
| **.NET** | Runtime and project platform |
| **Selenium WebDriver** | Web browser automation |
| **SpecFlow** | BDD automation framework |
| **Gherkin** | Human-readable test specification |
| **NUnit** | Test execution framework |
| **NuGet** | Dependency management |
| **Visual Studio** | Recommended development environment |
| **Git/GitHub** | Source control |

> Use the repository's `.csproj` file as the source of truth for exact package versions.

---

# 🏗️ BDD Architecture

```text
┌─────────────────────────────────────────────┐
│                 Feature Files               │
│                 *.feature                   │
│                                             │
│   Business-readable Gherkin scenarios       │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│              Step Definitions               │
│                  C# / *.cs                  │
│                                             │
│   Given / When / Then implementations       │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│                 Page Objects                │
│                  C# / *.cs                  │
│                                             │
│   Locators + reusable UI actions            │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│              Selenium WebDriver             │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│                 Web Browser                 │
└─────────────────────────────────────────────┘
```

---

# 📁 Project Structure

A scalable BDD solution generally separates the following responsibilities:

```text
csharp-specflow-web-ui-automation/
│
├── *.feature
│   └── Gherkin feature/scenario definitions
│
├── StepDefinitions/
│   └── C# implementations of Given/When/Then steps
│
├── Pages/
│   └── Page Object Model classes
│
├── Hooks/
│   └── SpecFlow lifecycle/browser hooks
│
├── Utilities/
│   └── Reusable framework helpers
│
├── Configuration/
│   └── Environment/application configuration
│
├── appsettings.json
│   └── Non-sensitive application settings
│
├── *.csproj
│   └── .NET project and NuGet configuration
│
├── *.sln
│   └── Visual Studio solution
│
├── .gitignore
└── README.md
```

> Folder names can vary with the repository implementation. The important design principle is separation of feature files, bindings, page objects, hooks, and utilities.

---

# 🔄 How the Framework Works

A typical scenario executes as follows:

### 1. Feature file is loaded

SpecFlow reads the Gherkin feature.

```gherkin
Scenario: Verify application navigation
    Given I am on the home page
    When I navigate to the required section
    Then the section should be displayed
```

### 2. SpecFlow resolves bindings

Each Gherkin step is mapped to a C# method.

```csharp
[Given(@"I am on the home page")]
public void GivenIAmOnTheHomePage()
{
    homePage.Open();
}
```

### 3. Step invokes a page object

```csharp
homePage.Open();
```

### 4. Page object uses Selenium

```csharp
driver.Navigate().GoToUrl(baseUrl);
```

### 5. Assertion validates the result

```csharp
Assert.That(pageTitle, Is.EqualTo(expectedTitle));
```

This separation keeps the feature readable while keeping browser implementation maintainable.

---

# 🥒 Gherkin and SpecFlow

Gherkin provides a structured syntax for expressing behavior.

## Feature

```gherkin
Feature: Login
```

## Scenario

```gherkin
Scenario: Login with valid credentials
```

## Given

Defines the initial state:

```gherkin
Given I am on the login page
```

## When

Represents an action:

```gherkin
When I enter valid credentials
```

## Then

Defines the expected outcome:

```gherkin
Then I should be logged in successfully
```

## And / But

```gherkin
Given I am on the login page
And the page is fully loaded
When I enter valid credentials
And I click Login
Then I should see the dashboard
```

---

# 📄 Feature Files

Feature files should describe **business behavior**, not Selenium implementation details.

### Recommended

```gherkin
Scenario: User searches for a product
    Given I am on the product page
    When I search for "Laptop"
    Then matching products should be displayed
```

### Avoid

```gherkin
Scenario: Click element with XPath
    Given I locate element "//input[@id='search']"
    When I call SendKeys with "Laptop"
    Then I click XPath "//button"
```

The second example exposes implementation details and makes feature files harder for non-technical stakeholders to understand.

---

# 🧩 Step Definitions

Step definitions connect Gherkin to C#.

Example:

```csharp
[When(@"I search for ""(.*)""")]
public void WhenISearchFor(string searchText)
{
    searchPage.Search(searchText);
}
```

A step definition should generally:

1. Receive Gherkin data.
2. Call a page object or business helper.
3. Avoid duplicating Selenium locator logic.
4. Keep assertions focused on expected behavior.

---

# 🧱 Page Object Model

The Page Object Model separates UI implementation from test behavior.

Example:

```csharp
public class LoginPage
{
    private readonly IWebDriver driver;

    private readonly By username =
        By.Id("username");

    private readonly By password =
        By.Id("password");

    private readonly By loginButton =
        By.Id("login");

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Login(string user, string pwd)
    {
        driver.FindElement(username).SendKeys(user);
        driver.FindElement(password).SendKeys(pwd);
        driver.FindElement(loginButton).Click();
    }
}
```

The step definition becomes:

```csharp
[When(@"I login with valid credentials")]
public void WhenILoginWithValidCredentials()
{
    loginPage.Login(username, password);
}
```

### Benefits

- Centralized locators
- Reduced duplication
- Easier maintenance
- Better readability
- Reusable UI actions
- Easier UI-change management

---

# 🌐 Browser Lifecycle

A browser driver should be created and disposed in a controlled manner.

Typical lifecycle:

```text
Scenario starts
      │
      ▼
Initialize WebDriver
      │
      ▼
Create Page Objects
      │
      ▼
Execute Given / When / Then
      │
      ▼
Capture failure artifacts
      │
      ▼
Dispose WebDriver
      │
      ▼
Scenario ends
```

A driver abstraction is recommended so that step definitions do not repeatedly create browser instances.

---

# 🪝 Hooks

SpecFlow hooks provide lifecycle control.

Example:

```csharp
[BeforeScenario]
public void BeforeScenario()
{
    // Initialize driver
}
```

And:

```csharp
[AfterScenario]
public void AfterScenario()
{
    // Capture artifacts and close browser
}
```

A useful lifecycle is:

```text
BeforeTestRun
    ↓
Initialize global configuration

BeforeScenario
    ↓
Create WebDriver
    ↓
Create page objects

Scenario
    ↓
Execute Given / When / Then

AfterScenario
    ↓
Capture screenshot if failed
    ↓
Close browser

AfterTestRun
    ↓
Finalize resources
```

---

# ⏱️ Synchronization and Waits

Modern web applications are asynchronous. Elements may not immediately exist or become interactable after navigation.

Prefer explicit waits.

Example:

```csharp
var wait = new WebDriverWait(
    driver,
    TimeSpan.FromSeconds(10));

wait.Until(
    SeleniumExtras.WaitHelpers
        .ExpectedConditions
        .ElementToBeClickable(locator));
```

Useful conditions include:

```text
ElementExists
ElementIsVisible
ElementToBeClickable
FrameToBeAvailableAndSwitchToIt
InvisibilityOfElementLocated
```

### Avoid excessive `Thread.Sleep`

Avoid:

```csharp
Thread.Sleep(5000);
```

Prefer a condition-based wait.

---

# 🧪 Test Data

Test data should be separated from browser interaction code.

Possible approaches:

```text
Gherkin Examples
        │
        ├── Small scenario datasets
        │
        ▼
JSON / CSV
        │
        ├── Larger datasets
        │
        ▼
Configuration
        │
        └── Environment-specific values
```

### Scenario Outline

```gherkin
Scenario Outline: Search with different keywords
    Given I am on the search page
    When I search for "<keyword>"
    Then the search results should be displayed

Examples:
    | keyword    |
    | Selenium   |
    | Automation |
    | Testing    |
```

---

# ⚙️ Configuration

Keep environment-specific configuration outside test implementation.

Example:

```json
{
  "BaseUrl": "https://example.com"
}
```

Recommended environment structure:

```text
appsettings.json
appsettings.dev.json
appsettings.qa.json
appsettings.stage.json
appsettings.prod.json
```

Do not commit:

```text
Passwords
API keys
Access tokens
Cloud credentials
Private certificates
```

Use environment variables or CI/CD secret stores for sensitive values.

---

# 💻 Prerequisites

Install:

1. A .NET SDK compatible with the project's target framework.
2. Visual Studio or another supported .NET IDE.
3. A supported browser such as Chrome, Edge, or Firefox.
4. Git.

Verify .NET:

```bash
dotnet --version
```

Verify Git:

```bash
git --version
```

---

# 📥 Installation

Clone the repository:

```bash
git clone https://github.com/vinodkpasi/csharp-specflow-web-ui-automation.git
```

Navigate to the project:

```bash
cd csharp-specflow-web-ui-automation
```

Restore dependencies:

```bash
dotnet restore
```

Build:

```bash
dotnet build
```

---

# 🔨 Build

Clean:

```bash
dotnet clean
```

Restore:

```bash
dotnet restore
```

Build:

```bash
dotnet build
```

Release build:

```bash
dotnet build --configuration Release
```

---

# ▶️ Run Tests

Run all tests:

```bash
dotnet test
```

Run with console output:

```bash
dotnet test --logger "console;verbosity=normal"
```

Run without rebuilding:

```bash
dotnet test --no-build
```

Run a specific project:

```bash
dotnet test <project>.csproj
```

---

# 🏷️ Run Tests by Tag

Gherkin tags are useful for organizing scenarios.

Example:

```gherkin
@smoke
Scenario: Verify login
```

Another:

```gherkin
@regression
Scenario: Verify search
```

Multiple tags:

```gherkin
@smoke @critical
Scenario: Verify checkout
```

Depending on the configured SpecFlow/NUnit integration, tags may be exposed as test categories/traits and selected using the corresponding test filter.

For NUnit category mappings, a typical filter can look like:

```bash
dotnet test --filter TestCategory=smoke
```

Use the exact category/filter representation generated by the project's configured adapter.

---

# 🖥️ Visual Studio Execution

Recommended workflow:

```text
Open .sln
   ↓
Restore NuGet packages
   ↓
Build Solution
   ↓
Open Test Explorer
   ↓
Discover tests
   ↓
Run selected scenarios
```

If scenarios are not visible:

```text
Clean
   ↓
Restore
   ↓
Build
   ↓
Check feature generation
   ↓
Re-open Test Explorer
```

---

# ⌨️ Command-Line Execution

A typical local/CI sequence:

```bash
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test --configuration Release --no-build
```

---

# 🐞 Debugging

When a scenario fails:

### 1. Identify the failing Gherkin step

```text
Feature
  └── Scenario
       └── Given / When / Then
```

### 2. Check the binding

Verify that the Gherkin text matches the C# binding.

### 3. Check the page object

Verify:

- Locator
- Wait condition
- Page state
- Navigation
- Frame/window context

### 4. Check application behavior

The UI may have changed:

- Element ID
- CSS selector
- DOM structure
- Loading behavior
- Authentication/session behavior
- Popup behavior

### 5. Capture a screenshot

Screenshots are highly useful for UI failure diagnosis.

---

# 📊 Reporting

The configured test runner can produce standard .NET/NUnit test results.

For CI environments, publish test results as pipeline artifacts.

A useful report should contain:

```text
Scenario
Feature
Status
Duration
Error
Screenshot
Logs
```

The framework can be extended with:

- Allure
- ExtentReports
- SpecFlow Living Documentation
- NUnit XML results
- CI-native test reporting

---

# 📸 Screenshots on Failure

A recommended lifecycle is:

```text
Scenario
   │
   ├── Passed
   │     └── Close browser
   │
   └── Failed
         │
         ├── Capture screenshot
         ├── Save artifacts
         ├── Log failure
         └── Close browser
```

Conceptually:

```csharp
[AfterScenario]
public void AfterScenario()
{
    if (scenarioContext.TestError != null)
    {
        // Capture screenshot
    }

    driver?.Quit();
}
```

Adapt the implementation to the exact SpecFlow version and test-runner APIs used by the project.

---

# ⚡ Parallel Execution

Parallel execution can reduce regression execution time, but UI tests must be isolated first.

Avoid shared mutable state:

```text
static IWebDriver
static page objects
shared user accounts
shared files
shared browser sessions
```

Prefer:

```text
Worker 1 → Driver 1 → Scenario 1
Worker 2 → Driver 2 → Scenario 2
Worker 3 → Driver 3 → Scenario 3
```

Before enabling parallel execution, verify:

- Independent WebDriver instances
- Independent test data
- No shared static state
- No shared temporary files
- Independent sessions
- Thread-safe utilities

---

# 🌐 Cross-Browser Execution

A scalable framework can support:

```text
Chrome
Edge
Firefox
```

A driver factory can centralize browser creation:

```csharp
public IWebDriver CreateDriver(string browser)
{
    switch (browser.ToLower())
    {
        case "chrome":
            return new ChromeDriver();

        case "edge":
            return new EdgeDriver();

        case "firefox":
            return new FirefoxDriver();

        default:
            throw new ArgumentException(
                $"Unsupported browser: {browser}");
    }
}
```

The browser can be selected using configuration or CI parameters.

---

# ☁️ Remote Browser / Cloud Execution

The framework can be extended to cloud platforms such as:

- BrowserStack
- LambdaTest / TestMu AI
- Sauce Labs
- Selenium Grid

Architecture:

```text
CI/CD
  │
  ▼
Test Runner
  │
  ▼
WebDriver Factory
  │
  ├── Local Chrome
  ├── Local Edge
  ├── Local Firefox
  │
  └── RemoteWebDriver
          │
          ▼
     Cloud Browser
```

Credentials should always be supplied through environment variables or secure CI/CD secrets.

---

# 🔄 CI/CD

The framework can be executed in:

- GitHub Actions
- Azure DevOps
- Jenkins
- GitLab CI/CD

Typical commands:

```bash
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test --configuration Release --no-build
```

Pipeline:

```text
Developer Push
      │
      ▼
Checkout Source
      │
      ▼
Install .NET
      │
      ▼
Restore Packages
      │
      ▼
Build
      │
      ▼
Run BDD Tests
      │
      ▼
Collect Results
      │
      ▼
Collect Screenshots / Logs
      │
      ▼
Publish Report
```

---

# 🧪 Recommended CI Test Strategy

Use tags to divide the suite:

```text
@smoke
@regression
@sanity
@critical
@e2e
```

Example:

```text
Pull Request
    ↓
@smoke

Main Branch
    ↓
@smoke + @regression

Nightly
    ↓
Full Regression
```

---

# 🔐 Security

Never store credentials in:

- `.feature`
- `.cs`
- `appsettings.json`
- Git repository
- CI files committed to source control

Use:

```text
Environment Variables
CI/CD Secret Store
Azure Key Vault
GitHub Secrets
Jenkins Credentials
```

Examples:

```text
BROWSERSTACK_USERNAME
BROWSERSTACK_ACCESS_KEY
TEST_USERNAME
TEST_PASSWORD
```

---

# 🧹 Best Practices

## Feature files

Keep them:

- Business readable
- Short
- Behavior focused
- Independent
- Free from Selenium implementation details

## Step definitions

Keep them:

- Thin
- Reusable
- Business focused
- Free from duplicated locators

## Page objects

Keep:

- Locators
- UI actions
- Synchronization
- Page-specific behavior

inside page classes.

## Assertions

Validate business behavior rather than Selenium implementation details.

Prefer:

```csharp
Assert.That(
    dashboardPage.IsDisplayed(),
    Is.True);
```

## Waits

Prefer explicit waits.

Avoid arbitrary:

```csharp
Thread.Sleep(...)
```

## Test data

Keep test data separate from UI implementation.

## Drivers

Avoid global static WebDriver instances when parallel execution is required.

---

# 🧭 Recommended Automation Design

```text
                    ┌──────────────────┐
                    │    Gherkin       │
                    │ Feature/Scenario │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │ Step Definitions │
                    └────────┬─────────┘
                             │
                ┌────────────┴────────────┐
                │                         │
                ▼                         ▼
        ┌──────────────┐          ┌──────────────┐
        │ Page Objects │          │ Test Context │
        └──────┬───────┘          └──────────────┘
               │
               ▼
        ┌──────────────┐
        │ WebDriver    │
        │ Factory      │
        └──────┬───────┘
               │
       ┌───────┼────────┐
       ▼       ▼        ▼
    Chrome    Edge    Firefox
```

---

# 🛠️ Troubleshooting

## Tests are not discovered

Try:

```bash
dotnet clean
dotnet restore
dotnet build
dotnet test
```

Also verify:

- Test SDK is installed.
- NUnit adapter is installed.
- SpecFlow integration is configured.
- Feature code generation succeeds.
- There are no compilation errors.

---

## Step definitions are not recognized

Check:

1. The class has the appropriate SpecFlow binding attribute.
2. The method has the correct `[Given]`, `[When]`, or `[Then]` attribute.
3. The Gherkin text matches the binding expression.
4. The project builds successfully.

Example:

```csharp
[Binding]
public class LoginSteps
{
    [Given(@"I am on the login page")]
    public void GivenIAmOnTheLoginPage()
    {
    }
}
```

---

## Browser does not start

Check:

- Browser installation
- Selenium package version
- Driver availability
- Browser/driver compatibility
- PATH configuration
- CI permissions

Modern Selenium versions can manage browser drivers automatically in many environments, but CI environments should still be validated explicitly.

---

## Element cannot be found

Check:

```text
Locator
   ↓
Page loaded?
   ↓
Element visible?
   ↓
Correct iframe?
   ↓
Correct browser window?
   ↓
Wait condition?
   ↓
Application state?
```

---

## Iframe issues

Switch into the frame:

```csharp
driver.SwitchTo().Frame(frameElement);
```

Return to the main document:

```csharp
driver.SwitchTo().DefaultContent();
```

---

## Multiple browser windows

After opening another window:

```csharp
var handles = driver.WindowHandles;

driver.SwitchTo().Window(handles.Last());
```

Always verify the target window before interacting with it.

---

# 📈 Recommended Enhancements

The framework can be extended with:

### Driver Factory

Centralize local and remote browser creation.

### Configuration Manager

Support:

```text
dev
qa
stage
prod
```

### Environment Variables

Allow CI to override configuration.

### Screenshot Utility

Capture screenshots automatically for failures.

### Logging

Consider:

- Serilog
- NLog
- Microsoft.Extensions.Logging

### Rich Reporting

Consider:

- Allure
- ExtentReports
- Living Documentation

### API Helpers

Use API calls for fast test-data setup/cleanup where appropriate.

### Test Data Factory

Generate unique test data instead of relying on shared static accounts.

### Retry Strategy

Use retries only for known transient infrastructure issues; do not use retries to hide genuine product defects.

### CI/CD

Add a GitHub Actions, Azure DevOps, or Jenkins workflow.

### Cloud Browser Execution

Add BrowserStack, LambdaTest/TestMu AI, Sauce Labs, or Selenium Grid.

### Parallel Execution

Introduce scenario-level parallelization after test isolation is guaranteed.

---

# 🔁 SpecFlow and Reqnroll Note

**SpecFlow is a legacy technology choice for new .NET BDD projects.** The SpecFlow project was discontinued, and the .NET BDD ecosystem has moved toward alternatives such as **Reqnroll**.

For a modernization path:

```text
Existing

C#
 +
Selenium
 +
SpecFlow
 +
Gherkin
 +
NUnit

        │
        ▼

Modernized

C#
 +
Selenium
 +
Reqnroll
 +
Gherkin
 +
NUnit
```

Before migrating, evaluate:

- NuGet packages
- Generated feature code
- Bindings
- Hooks
- NUnit integration
- CI/CD
- Reporting
- IDE extensions
- Existing custom plugins

Keeping Gherkin scenarios and page objects cleanly separated makes this type of migration easier.

---

# 📚 BDD Concepts Demonstrated

This repository is useful for learning:

- Behavior Driven Development
- Gherkin
- Feature files
- Scenarios
- Scenario Outlines
- Examples tables
- Step definitions
- SpecFlow bindings
- SpecFlow hooks
- Page Object Model
- Selenium WebDriver
- Explicit waits
- Browser lifecycle management
- NUnit execution
- Test data management
- Cross-browser architecture
- CI/CD automation

---

# 🧑‍💻 Example End-to-End Scenario

### Feature

```gherkin
Feature: Search

  Scenario: Search for a valid keyword
    Given I am on the search page
    When I search for "Selenium"
    Then search results should be displayed
```

### Step definition

```csharp
[When(@"I search for ""(.*)""")]
public void WhenISearchFor(string keyword)
{
    searchPage.Search(keyword);
}
```

### Page object

```csharp
public void Search(string keyword)
{
    searchBox.SendKeys(keyword);
    searchButton.Click();
}
```

### Result

```text
Gherkin
   ↓
Step Definition
   ↓
Page Object
   ↓
Selenium
   ↓
Browser
   ↓
Application
```

---

# 📝 Git Workflow

Create a feature branch:

```bash
git checkout -b feature/add-login-tests
```

Review:

```bash
git status
```

Stage:

```bash
git add .
```

Commit:

```bash
git commit -m "Add login BDD scenarios"
```

Push:

```bash
git push origin feature/add-login-tests
```

Then create a Pull Request.

---

# 🤝 Contributing

Contributions are welcome.

Before submitting a change:

1. Build the solution.
2. Run relevant tests.
3. Verify feature files remain readable.
4. Avoid duplicated step definitions.
5. Keep Selenium implementation inside page objects.
6. Do not commit secrets.
7. Update documentation when framework behavior changes.

---

# 📄 License

No explicit license information is assumed in this README.

If this repository is intended for public reuse, add an appropriate `LICENSE` file to clearly define usage and distribution rights.

---

# 👤 Author

## Vinod Kumar

**Lead SDET / QA Automation Leader**

Areas of expertise include:

- C#
- Selenium
- Playwright
- SpecFlow / BDD
- Reqnroll
- NUnit
- TypeScript
- API automation
- CI/CD
- GitHub Actions
- Azure DevOps
- Jenkins
- BrowserStack
- Test automation framework design

### GitHub

https://github.com/vinodkpasi

### Repository

https://github.com/vinodkpasi/csharp-specflow-web-ui-automation

---

# ⭐ Support

If this project is useful for learning or demonstrating C# BDD web automation, consider giving the repository a ⭐ on GitHub.

---

## 📚 Useful References

- Selenium WebDriver — https://www.selenium.dev/
- Gherkin — https://cucumber.io/docs/gherkin/
- NUnit — https://nunit.org/
- .NET — https://dotnet.microsoft.com/
- SpecFlow — https://specflow.org/
- Reqnroll — https://reqnroll.net/
