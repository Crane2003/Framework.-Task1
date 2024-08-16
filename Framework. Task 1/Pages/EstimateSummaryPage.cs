using OpenQA.Selenium;

namespace Framework._Task_1.Pages;

public class EstimateSummaryPage
{
    private readonly IWebDriver _driver;

    public EstimateSummaryPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public Dictionary<string, string> GetSummary()
    {
        var actualValues = new Dictionary<string, string>
        {
            ["numberOfInstances"] = GetElement("Number of Instances"),

            ["operatingSystem"] = GetElement("Operating System / Software"),

            ["provisioningModel"] = GetElement("Provisioning Model"),

            ["machineType"] = GetElement("Machine type"),

            ["gpuType"] = GetElement("GPU Model"),

            ["numberOfGPUs"] = GetElement("Number of GPUs"),

            ["localSSD"] = GetElement("Local SSD"),

            ["region"] = GetElement("Region")
        };

        return actualValues;
    }

    private string GetElement(string label)
    {
        var element = _driver.FindElement(By.XPath($"//span[@class='Z7Pe2d g5Ano'][.//span[@class='zv7tnb' and text()='{label}']]//span[@class='Kfvdz']"));

        string extractedText = element.Text;
        return extractedText;
    }
}
