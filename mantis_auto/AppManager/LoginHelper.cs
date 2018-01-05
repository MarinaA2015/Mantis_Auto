using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_auto
{
    class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        {            
        }

       
        public LoginHelper LoginToTheSystem(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return this;
                }
                Logout();
                //LoginToTheSystem(account);              
            }
            OpenMainPage();
            FillLogin(account.Name);
            PressLoginButton();
            FillPassword(account.Password);
            PressLoginButton();
            return this;
        }

        private bool IsLoggedIn()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementPresent(By.CssSelector("span.smaller-75"));
        }

        private bool IsLoggedIn(AccountData account)
        {
            System.Threading.Thread.Sleep(1000);
            return (driver.FindElement(By.CssSelector(".breadcrumb li a")).Text == account.Name);

        }

        private LoginHelper Logout()
        {
            driver.FindElement(By.CssSelector("span.user-info")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//a[contains(text(),'Logout')]")).Click();
            System.Threading.Thread.Sleep(1000);
            return this;
        }

        public LoginHelper OpenMainPage()
        {
            driver.Url = "http://localhost/mantisbt-2.9.0/mantisbt-2.9.0/login_page.php";
            return this;
        }

        private LoginHelper FillLogin(string login)
        {
            driver.FindElement(By.Id("username")).SendKeys(login);
            return this;
        }

        private LoginHelper FillPassword(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
            return this;
        }

        private void PressLoginButton()
        {
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
        }

        public LoginHelper LogOut()
        {
            
            driver.FindElement(By.XPath(".//span[contains(text(),'administrator')]")).Click();
            driver.FindElement(By.XPath(".//a[contains(text(),'Logout')]")).Click();
            return this;
        }

    }
}
