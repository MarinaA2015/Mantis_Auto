using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_auto
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Register(AccountData account)
        {
            //if (manager.Login.IsLoggedIn())
             //   manager.Login.LogOut();
            System.Threading.Thread.Sleep(1000);

            manager.Login.OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url,account);
            SubmitPasswordForm();

        }

        private void SubmitPasswordForm()
        {
            manager.Driver.FindElement(By.CssSelector("button[type = 'submit']")).Click();
        }

        private void FillPasswordForm(String url,AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("password-confirm")).SendKeys(account.Password);
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message,@"http://\S*");
            return match.Value;

        }

        private void OpenRegistrationForm()
        {
            manager.Driver.FindElement(By.XPath("(.//*[@class='widget-body']/*)[2]/*")).Click();
        }

        private void SubmitRegistration()
        {
            manager.Driver.FindElement(By.CssSelector("input[type = 'submit']")).Click();
            
        }

        private void FillRegistrationForm(AccountData account)
        {
            System.Threading.Thread.Sleep(1000);
            manager.Driver.FindElement(By.CssSelector("#username")).SendKeys(account.Name);
            //manager.Driver.FindElement(By.CssSelector("input[id='username']")).SendKeys(account.Name);
            //manager.Driver.FindElement(By.Id("email-field")).SendKeys(account.Email);
            manager.Driver.FindElement(By.CssSelector("#email-field")).SendKeys(account.Email);
        }

       
    }
}
