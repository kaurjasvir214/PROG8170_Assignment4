using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UnitTest1
{
    [TestFixture]
    public class Assignment4
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void InvalidPhoneNumber()
        {
            driver.Navigate().GoToUrl("http://localhost:49762/Sale/AddInfo");
            driver.FindElement(By.Name("_name")).Click();
            driver.FindElement(By.Name("_name")).Clear();
            driver.FindElement(By.Name("_name")).SendKeys("Test");
            driver.FindElement(By.Name("_name")).SendKeys(Keys.Down);
            driver.FindElement(By.Name("_name")).SendKeys(Keys.Tab);
            driver.FindElement(By.Name("_contact_no")).Clear();
            driver.FindElement(By.Name("_contact_no")).SendKeys("fdgjdkf");
            driver.FindElement(By.Name("_contact_email")).Clear();
            driver.FindElement(By.Name("_contact_email")).SendKeys("sdsfsd@gmail.com");
            driver.FindElement(By.Name("_address")).Clear();
            driver.FindElement(By.Name("_address")).SendKeys("Addess3");
            driver.FindElement(By.Name("_city")).Clear();
            driver.FindElement(By.Name("_city")).SendKeys("Kithchner");
            driver.FindElement(By.Name("_car_make")).Clear();
            driver.FindElement(By.Name("_car_make")).SendKeys("Honda");
            driver.FindElement(By.Name("_car_model")).Clear();
            driver.FindElement(By.Name("_car_model")).SendKeys("Accord Coupe");
            driver.FindElement(By.Name("_car_year")).Click();
            driver.FindElement(By.Name("_car_year")).Clear();
            driver.FindElement(By.Name("_car_year")).SendKeys("2014");
            driver.FindElement(By.Id("btnSubmit")).Click();
        }
        [Test]
        public void InValidEmail()
        {
            driver.Navigate().GoToUrl("http://localhost:49762/");
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Name("_name")).Click();
            driver.FindElement(By.Name("_name")).Clear();
            driver.FindElement(By.Name("_name")).SendKeys("John");
            driver.FindElement(By.Name("_contact_no")).Clear();
            driver.FindElement(By.Name("_contact_no")).SendKeys("519-159-7894");
            driver.FindElement(By.Name("_contact_email")).Click();
            driver.FindElement(By.Name("_contact_email")).Clear();
            driver.FindElement(By.Name("_contact_email")).SendKeys("sdfhsdfgj");
            driver.FindElement(By.Name("_address")).Clear();
            driver.FindElement(By.Name("_address")).SendKeys("Test Addres");
            driver.FindElement(By.Name("_city")).Clear();
            driver.FindElement(By.Name("_city")).SendKeys("Toronto");
            driver.FindElement(By.Name("_car_make")).Clear();
            driver.FindElement(By.Name("_car_make")).SendKeys("Ford");
            driver.FindElement(By.Name("_car_model")).Clear();
            driver.FindElement(By.Name("_car_model")).SendKeys("Mustang");
            driver.FindElement(By.Name("_car_year")).Clear();
            driver.FindElement(By.Name("_car_year")).SendKeys("2014");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Contact Email'])[1]/following::div[1]")).Click();
            driver.FindElement(By.Id("btnSubmit")).Click();
        }

        [Test]
        public void InValidYear()
        {
            driver.Navigate().GoToUrl("http://localhost:49762/");
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Name("_name")).Click();
            driver.FindElement(By.Name("_name")).Click();
            driver.FindElement(By.Name("_name")).Clear();
            driver.FindElement(By.Name("_name")).SendKeys("John");
            driver.FindElement(By.Name("_contact_no")).Click();
            driver.FindElement(By.Name("_contact_no")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_contact_no | ]]
            driver.FindElement(By.Name("_contact_no")).Clear();
            driver.FindElement(By.Name("_contact_no")).SendKeys("519-159-7894");
            driver.FindElement(By.Name("_contact_email")).Click();
            driver.FindElement(By.Name("_contact_email")).Click();
            driver.FindElement(By.Name("_contact_email")).Clear();
            driver.FindElement(By.Name("_contact_email")).SendKeys("asdasd@gmail.com");
            driver.FindElement(By.Name("_address")).Click();
            driver.FindElement(By.Name("_address")).Click();
            driver.FindElement(By.Name("_address")).Clear();
            driver.FindElement(By.Name("_address")).SendKeys("Addess3");
            driver.FindElement(By.Name("_city")).Click();
            driver.FindElement(By.Name("_city")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_city | ]]
            driver.FindElement(By.Name("_city")).Clear();
            driver.FindElement(By.Name("_city")).SendKeys("Toronto");
            driver.FindElement(By.Name("_car_make")).Click();
            driver.FindElement(By.Name("_car_make")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_car_make | ]]
            driver.FindElement(By.Name("_car_make")).Clear();
            driver.FindElement(By.Name("_car_make")).SendKeys("Ford");
            driver.FindElement(By.Name("_car_model")).Click();
            driver.FindElement(By.Name("_car_model")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_car_model | ]]
            driver.FindElement(By.Name("_car_model")).Clear();
            driver.FindElement(By.Name("_car_model")).SendKeys("Mustang");
            driver.FindElement(By.Name("_car_year")).Click();
            driver.FindElement(By.Name("_car_year")).Clear();
            driver.FindElement(By.Name("_car_year")).SendKeys("2019");
            driver.FindElement(By.Id("btnSubmit")).Click();
        }


        [Test]
        public void InsertValidRecord()
        {
            driver.Navigate().GoToUrl("http://localhost:49762/");
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Name("_name")).Click();
            driver.FindElement(By.Name("_name")).Click();
            driver.FindElement(By.Name("_name")).Clear();
            driver.FindElement(By.Name("_name")).SendKeys("John");
            driver.FindElement(By.Name("_contact_no")).Click();
            driver.FindElement(By.Name("_contact_no")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_contact_no | ]]
            driver.FindElement(By.Name("_contact_no")).Clear();
            driver.FindElement(By.Name("_contact_no")).SendKeys("519-159-7894");
            driver.FindElement(By.Name("_contact_email")).Click();
            driver.FindElement(By.Name("_contact_email")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_contact_email | ]]
            driver.FindElement(By.Name("_contact_email")).Clear();
            driver.FindElement(By.Name("_contact_email")).SendKeys("asdasd@gmail.com");
            driver.FindElement(By.Name("_address")).Click();
            driver.FindElement(By.Name("_address")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_address | ]]
            driver.FindElement(By.Name("_address")).Clear();
            driver.FindElement(By.Name("_address")).SendKeys("Addess3");
            driver.FindElement(By.Name("_city")).Click();
            driver.FindElement(By.Name("_city")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_city | ]]
            driver.FindElement(By.Name("_city")).Clear();
            driver.FindElement(By.Name("_city")).SendKeys("Toronto");
            driver.FindElement(By.Name("_car_make")).Click();
            driver.FindElement(By.Name("_car_make")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=_car_make | ]]
            driver.FindElement(By.Name("_car_make")).Clear();
            driver.FindElement(By.Name("_car_make")).SendKeys("Ford");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Add Car'])[1]/following::div[4]")).Click();
            driver.FindElement(By.Name("_car_model")).Click();
            driver.FindElement(By.Name("_car_model")).Click();
            driver.FindElement(By.Name("_car_model")).Clear();
            driver.FindElement(By.Name("_car_model")).SendKeys("Mustang");
            driver.FindElement(By.Name("_car_year")).Click();
            driver.FindElement(By.Name("_car_year")).Click();
            driver.FindElement(By.Name("_car_year")).Clear();
            driver.FindElement(By.Name("_car_year")).SendKeys("2014");
            driver.FindElement(By.Id("btnSubmit")).Click();
        }

        [Test]
        public void RequiredFields()
        {
            driver.Navigate().GoToUrl("http://localhost:49762/Sale/AddInfo");
            driver.FindElement(By.Name("_name")).Click();
            driver.FindElement(By.Name("_name")).Clear();
            driver.FindElement(By.Name("_name")).SendKeys("John");
            driver.FindElement(By.Name("_contact_no")).Click();
            driver.FindElement(By.Name("_contact_no")).Clear();
            driver.FindElement(By.Name("_contact_no")).SendKeys("519-159-7894");
            driver.FindElement(By.Id("btnSubmit")).Click();
            driver.FindElement(By.Name("_car_make")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
