using Framework._Task_1.Driver;
using Framework._Task_1.Helpers;
using Framework._Task_1.Model;
using Framework._Task_1.Pages;
using OpenQA.Selenium;

namespace Framework._Task_1.Tests;

[TestClass]
public class CalculatorTests
{
    private WebDriverManager _webDriverManager;
    private IWebDriver _driver;
    private CalculatorPage calculatorPage;
    private EstimateSummaryPage estimateSummaryPage;
    private ConfigurationHelper config;
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void Setup()
    {
        _webDriverManager = new WebDriverManager();
        _driver = _webDriverManager.GetDriver("chrome");
        calculatorPage = new CalculatorPage(_driver);
        estimateSummaryPage = new EstimateSummaryPage(_driver);
        config = new ConfigurationHelper("C:\\Users\\myasn\\source\\repos\\Framework. Task 1\\Framework. Task 1\\Model\\testdata-qa1.properties");
    }

    [TestCleanup]
    public void Teardown()
    {
        if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
        {
            ScreenshotHelper.TakeScreenshot(_driver, TestContext.TestName);
        }
       // _webDriverManager.QuitDriver();
    }

    [TestMethod]
    public void VerifyCostEstimate()
    {
        var estimateData = new EstimateData
        {
            NumberOfInstances = config.GetValue("numberOfInstances"),
            OperatingSystem = config.GetValue("operatingSystem"),
            ProvisioningModel = config.GetValue("provisioningModel"),
            MachineType = config.GetValue("machineType"),
            MachineFamily = config.GetValue("machineFamily"),
            Series = config.GetValue("series"),
            GPUType = config.GetValue("gpuType"),
            NumberOfGPUs = config.GetValue("numberOfGPUs"),
            LocalSSD = config.GetValue("localSSD"),
            Region = config.GetValue("region")
        };

        calculatorPage.Open();
        calculatorPage.AddComputeEngine();
        calculatorPage.FillForm(estimateData);
        calculatorPage.SubmitAndVerify();

        var windows = _driver.WindowHandles;
        _driver.SwitchTo().Window(windows[1]);
        Dictionary<string, string> actualValues = estimateSummaryPage.GetSummary();

        Assert.IsTrue(CompareDictionaries(actualValues));
    }

    bool CompareDictionaries(Dictionary<string, string> actualValues)
    {
        foreach (var key in actualValues.Keys)
        {
            if (!actualValues[key].Contains(config.GetValue(key)))
            {
                return false;
            }
        }
        return true;
    }
}
