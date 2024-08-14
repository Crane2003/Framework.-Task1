using Framework._Task_1.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework._Task_1.Pages
{
    public class CalculatorPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        private IWebElement AddToEstimateButton => driver.FindElement(By.CssSelector(".UywwFc-LgbsSe.UywwFc-LgbsSe-OWXEXe-Bz112c-M1Soyc.UywwFc-LgbsSe-OWXEXe-dgl2Hf.xhASFc"));
        private IWebElement ComputeEngineLink;
        private IWebElement InstancesField;
        private IWebElement OSDropDown;
        private IWebElement ProvisioningModel;
        private IWebElement MachineFamilyDropdown;
        private IWebElement SeriesDropdown;
        private IWebElement MachineTypeDropdown;
        private IWebElement AddGPUsButton;
        private IWebElement GPUTypeDropdown;
        private IWebElement NumberOfGPUsDropdown;
        private IWebElement LocalSSDDropdown;
        private IWebElement RegionDropdown;
        private IWebElement EstimateButton;
        private IWebElement ShareButton;


        public void Open()
        {
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/");
            /*            _driver.Navigate().GoToUrl(
                            "https://cloud.google.com/products/calculator/?dl=CiRmOTQxNWRmNy0xMTEyLTQxZjktYjg4My02Y2NlZWVjMjZiYmQQCBokRjBDMDNBRDctQTNBRC00NDgwLUE2REItRjdGMzZEMEIyMjdF"
                            );*/
        }

        public void AddComputeEngine()
        {
            AddToEstimateButton.Click();
            ComputeEngineLink = driver.FindElement(By.CssSelector(".aHij0b-aGsRMb"));
            wait.Until(drv => ComputeEngineLink.Displayed && ComputeEngineLink.Enabled);
            ComputeEngineLink.Click();
        }

        public void FillForm(EstimateData estimateData)
        {
            //GetFormElements();
            Thread.Sleep(2000);
            InstancesField = driver.FindElement(By.CssSelector(".qdOxv-fmcmS-wGMbrd"));
            ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].value='{estimateData.NumberOfInstances}';", InstancesField);

            SelectOptionWithTextToMacth(estimateData.OperatingSystem);

            ProvisioningModel = driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[9]/div/div/div[2]/div/div/div[1]/label"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", ProvisioningModel);

            SelectOptionWithTextToMacth(estimateData.MachineFamily);

            SelectOptionWithTextToMacth(estimateData.Series);

            SelectOptionWithTextToMacth(estimateData.MachineType);

            AddGPUsButton = driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[21]/div/div/div[1]/div/div/span/div/button"));
            AddGPUsButton.Click();
            Thread.Sleep(2000);

            //GetGPUForm();
            SelectOptionWithTextToMacth(estimateData.GPUType);
            //GPUTypeDropdown.Click();
            //driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[2]/ul/li[2]")).Click();

            SelectOptionWithTextToMacth(estimateData.NumberOfGPUs);

            SelectOptionWithTextToMacth(estimateData.LocalSSD);

            SelectOptionWithTextToMacth(estimateData.Region);
            Thread.Sleep(2000);
        }       

        public void SubmitAndVerify()
        {

            ShareButton = driver.FindElement(By.CssSelector("[aria-label='Open Share Estimate dialog']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", ShareButton);

            EstimateButton = wait.Until(drv => drv.FindElement(By.CssSelector(".tltOzc.MExMre.rP2xkc.jl2ntd")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", EstimateButton);
        }

        public void GetFormElements()
        {
           // Thread.Sleep(2000);
            InstancesField = driver.FindElement(By.CssSelector(".qdOxv-fmcmS-wGMbrd"));
            OSDropDown = driver.FindElement(By.CssSelector(".VfPpkd-uusGie-fmcmS-haAclf"));
            ProvisioningModel = driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[9]/div/div/div[2]/div/div/div[1]/label"));
            MachineFamilyDropdown = driver.FindElement(By.CssSelector("[jsname='Wsw6tc']"));
            SeriesDropdown = driver.FindElement(By.CssSelector("[jsname='vGGDlb']"));
            MachineTypeDropdown = driver.FindElement(By.CssSelector("[jsname='kgDJk']"));
            AddGPUsButton = driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[21]/div/div/div[1]/div/div/span/div/button"));
        }

        public void GetGPUForm()
        {
            GPUTypeDropdown = wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[1]/div")));
            NumberOfGPUsDropdown = driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[24]/div/div[1]/div/div/div/div[1]/div"));
            LocalSSDDropdown = driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[1]/div"));
            RegionDropdown = driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[29]/div/div[1]/div/div/div/div[1]/div"));

        }

        private void SelectOptionWithTextToMacth(string textToMatch)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
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

}
