using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProjectAsim.Pages
{
    public class ProductsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        // Locator
        private By ProductsTitle = By.ClassName("title");

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(10)
            );
        }

        public string GetProductsTitle()
        {
            wait.Until(d =>
                d.FindElement(ProductsTitle).Displayed
            );

            return driver.FindElement(ProductsTitle).Text;
        }
    }
}