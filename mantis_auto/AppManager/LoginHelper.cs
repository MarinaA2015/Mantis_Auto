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

       
        public void LoginToTheSystem(AccountData account)
        {
            OpenMainPage();
            FillLogin(account.Name);
            PressLoginButton();
            FillPassword(account.Password);
            PressLoginButton();

        }
      
        public LoginHelper OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.9.0/mantisbt-2.9.0/login_page.php";
            return this;
        }

        private LoginHelper FillLogin(string login)
        {
            manager.Driver.FindElement(By.Id("username")).SendKeys(login);
            return this;
        }

        private LoginHelper FillPassword(string password)
        {
            manager.Driver.FindElement(By.Id("password")).SendKeys(password);
            return this;
        }

        private void PressLoginButton()
        {
            manager.Driver.FindElement(By.XPath("//*[@type='submit']")).Click();
        }

        public LoginHelper LogOut()
        {
            
            manager.Driver.FindElement(By.XPath(".//span[contains(text(),'administrator')]")).Click();
            manager.Driver.FindElement(By.XPath(".//a[contains(text(),'Logout')]")).Click();
            return this;
        }

    }
}
