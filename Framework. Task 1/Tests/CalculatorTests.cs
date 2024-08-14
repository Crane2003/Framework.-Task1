using Framework._Task_1.Config;
using Framework._Task_1.Driver;
using Framework._Task_1.Helpers;
using Framework._Task_1.Pages;
using OpenQA.Selenium;

namespace Framework._Task_1.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private WebDriverManager webDriverManager;
        private IWebDriver driver;
        private CalculatorPage calculatorPage;
        private EstimateSummaryPage estimateSummaryPage;
        private ConfigurationHelper config;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            webDriverManager = new WebDriverManager();
            driver = webDriverManager.GetDriver("chrome");
            calculatorPage = new CalculatorPage(driver);
            estimateSummaryPage = new EstimateSummaryPage(driver);
            config = new ConfigurationHelper("C:\\Users\\myasn\\source\\repos\\Framework. Task 1\\Framework. Task 1\\Model\\testdata-qa1.properties");
        }

        [TestCleanup]
        public void Teardown()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                ScreenshotHelper.TakeScreenshot(driver, TestContext.TestName);
            }
            //webDriverManager.QuitDriver();
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

            var windows = driver.WindowHandles;
            driver.SwitchTo().Window(windows[1]);

            Dictionary<string, string> actualValues = estimateSummaryPage.GetSummary();
            Assert.IsTrue(CompareDictionaries(actualValues));
        }

        bool CompareDictionaries(Dictionary<string, string> actualValues)
        {
            foreach (var key in actualValues.Keys)
            {
                if (config.GetValue(key).Trim() != actualValues[key].Trim())
                {
                    return false;
                }
            }
            return true;
        }
    }

}
