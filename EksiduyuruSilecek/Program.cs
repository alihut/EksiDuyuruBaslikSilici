using OpenQA.Selenium;
using System;

namespace EksiduyuruSilecek
{
    internal class Program
    {
        public static string UserName = "YOUR_USER_NAME";

        public static string Password = "YOUR_PASSWORD";

        static void Main(string[] args)
        {
            WebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();

            driver.Url = "http://www.eksiduyuru.com/";
            IWebElement element = driver.FindElement(By.ClassName("login"));
            element.Click();

            IWebElement userNameEntry =  driver.FindElement(By.Name("username"));
            userNameEntry.SendKeys(UserName);
            IWebElement passwordEntry = driver.FindElement(By.Name("password"));
            passwordEntry.SendKeys(Password);

            driver.FindElement(By.Name("SubmitExistingUser")).Click();

            while(driver.FindElements(By.ClassName("entry0")).Count > 0)
                DeleteTheLastQuestion(driver);
        }

        private static void DeleteTheLastQuestion(WebDriver driver)
        {
            driver.Url = "https://www.eksiduyuru.com/ben/";

            var questionDiv = driver.FindElement(By.ClassName("entry0"));
            var deleteButton = questionDiv.FindElement(By.ClassName("spt-del"));

            deleteButton.Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> windowhandles = driver.WindowHandles;

            driver.SwitchTo().Window(windowhandles[1]);

            driver.FindElement(By.Name("s")).Click();
            driver.Close();
            driver.SwitchTo().Window(windowhandles[0]);
        }
    }
}
