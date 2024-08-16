using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework._Task_1.Driver;

public class WebDriverManager
{
    private IWebDriver _driver;

    public IWebDriver GetDriver(string browser)
    {
        switch (browser.ToLower())
        {
            case "chrome":
                _driver = new ChromeDriver();
                break;
            case "firefox":
                _driver = new FirefoxDriver();
                break;
            default:
                _driver = new ChromeDriver();
                break;
        }

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _driver.Manage().Window.Maximize();
        return _driver;
    }

    public void QuitDriver()
    {
        _driver.Quit();
        _driver = null;
    }
}
