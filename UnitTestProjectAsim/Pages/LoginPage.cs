using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProjectAsim.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        // Locators
        private By UsernameField = By.Id("user-name");
        private By PasswordField = By.Id("password");
        private By LoginButton = By.Id("login-button");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(10)
            );
        }

        public void EnterUsername(string username)
        {
            wait.Until(d =>
                d.FindElement(UsernameField).Displayed
            );

            driver.FindElement(UsernameField)
                  .SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(PasswordField)
                  .SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(LoginButton)
                  .Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
    }
}