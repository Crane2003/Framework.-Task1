using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework._Task_1.Pages
{
    public class EstimateSummaryPage
    {
        private readonly IWebDriver driver;

        public EstimateSummaryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Dictionary<string, string> GetSummary()
        {
            // Get the actual values from the page
            var actualValues = new Dictionary<string, string>();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            // Number of instances
            actualValues["Number of instances"] = wait.Until(drv => drv.FindElement(By.CssSelector("#yDmH0d > c-wiz.SSPGKf > div > div > div > div > div.qBohdf.AlLELb > div.oijjFb > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(7) > span > span.Z7Pe2d.g5Ano > span.Kfvdz"))).Text;

            // Operating System / Software
            actualValues["Operating System / Software"] = driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[8]/span/span[1]/span[2]")).Text;

            // Provisioning model
            actualValues["Provisioning model"] = driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[9]/span/span[1]/span[2]")).Text;

            // Machine type
            actualValues["Machine type"] = driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[3]/span[2]/span[1]/span[2]")).Text;

            // GPU type
            actualValues["GPU type"] = driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[4]/span[2]/span[1]/span[2]")).Text;

            // Number of GPUs
            actualValues["Number of GPUs"] = driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[4]/span[3]/span[1]/span[2]")).Text;

            // Local SSD
            actualValues["Local SSD"] = driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[5]/span/span[1]/span[2]")).Text;

            // Region
            actualValues["Region"] = driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[15]/span/span[1]/span[2]")).Text;

            // Compare actual values with expected values
            return actualValues;
        }
    }
}
