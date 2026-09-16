using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProjectAsim.Pages;

namespace UnitTestProjectAsim.Tests
{
    [TestClass]
    public class LoginTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"TestData\Data.xml",
            "LoginTest",
            DataAccessMethod.Sequential
        )]
        public void LoginTest()
        {
            // Read data from XML
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string expectedTitle = TestContext.DataRow["expectedTitle"].ToString();

            // Start browser
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Manage().Window.Maximize();

                // Open website
                driver.Navigate().GoToUrl(url);

                // Create Page Objects
                LoginPage loginPage = new LoginPage(driver);
                ProductsPage productsPage = new ProductsPage(driver);

                // Perform login
                loginPage.Login(username, password);

                // Get Products page title
                string actualTitle = productsPage.GetProductsTitle();

                // Verify result
                Assert.AreEqual(expectedTitle, actualTitle);
            }
            finally
            {
                // Close browser
                driver.Quit();
            }
        }
    }
}