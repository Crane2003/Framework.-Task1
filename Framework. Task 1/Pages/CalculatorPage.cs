using Framework._Task_1.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework._Task_1.Pages;

public class CalculatorPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public CalculatorPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
    }

    private IWebElement AddToEstimateButton => _driver.FindElement(By.CssSelector(".UywwFc-LgbsSe.UywwFc-LgbsSe-OWXEXe-Bz112c-M1Soyc.UywwFc-LgbsSe-OWXEXe-dgl2Hf.xhASFc"));
    private IWebElement ComputeEngineLink;
    private IWebElement InstancesField;
    private IWebElement ProvisioningModel;
    private IWebElement AddGPUsButton;
    private IWebElement EstimateButton;
    private IWebElement ShareButton;

    public void Open()
    {
        _driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/");
    }

    public void AddComputeEngine()
    {
        AddToEstimateButton.Click();
        ComputeEngineLink = _driver.FindElement(By.CssSelector(".aHij0b-aGsRMb"));
        _wait.Until(drv => ComputeEngineLink.Displayed && ComputeEngineLink.Enabled);
        ComputeEngineLink.Click();
    }

    public void FillForm(EstimateData estimateData)
    {
        Thread.Sleep(1000);
        InstancesField = _driver.FindElement(By.CssSelector(".qdOxv-fmcmS-wGMbrd"));
        ((IJavaScriptExecutor)_driver).ExecuteScript($"arguments[0].value='{estimateData.NumberOfInstances}';", InstancesField);

        SelectOptionEqualsTextToMacth(estimateData.OperatingSystem);

        ProvisioningModel = _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[9]/div/div/div[2]/div/div/div[1]/label"));
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ProvisioningModel);

        SelectOptionEqualsTextToMacth(estimateData.MachineFamily);

        SelectOptionEqualsTextToMacth(estimateData.Series);

        SelectOptionContainsTextToMacth(estimateData.MachineType);

        AddGPUsButton = _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[21]/div/div/div[1]/div/div/span/div/button"));
        AddGPUsButton.Click();
        Thread.Sleep(1000);

        SelectOptionEqualsTextToMacth(estimateData.GPUType);

        SelectOptionEqualsTextToMacth(estimateData.NumberOfGPUs);

        SelectOptionEqualsTextToMacth(estimateData.LocalSSD);

        SelectOptionEqualsTextToMacth(estimateData.Region);
        Thread.Sleep(2000);
    }

    public void SubmitAndVerify()
    {

        ShareButton = _driver.FindElement(By.CssSelector("[aria-label='Open Share Estimate dialog']"));
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ShareButton);

        EstimateButton = _wait.Until(drv => drv.FindElement(By.CssSelector(".tltOzc.MExMre.rP2xkc.jl2ntd")));
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", EstimateButton);
    }

    private void SelectOptionEqualsTextToMacth(string textToMatch)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript($@"
    var items = document.querySelectorAll('li.MCs1Pd');
    for (var i = 0; i < items.length; i++) {{
        if (items[i].innerText === '{textToMatch}') {{
            items[i].click();
            break;
        }}
    }}");
    }

    private void SelectOptionContainsTextToMacth(string textToMatch)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript($@"
    var items = document.querySelectorAll('li.MCs1Pd');
    for (var i = 0; i < items.length; i++) {{
        if (items[i].innerText.includes('{textToMatch}')) {{
            items[i].click();
            break;
        }}
    }}");
    }
}
