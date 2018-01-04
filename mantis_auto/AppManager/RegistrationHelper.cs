using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_auto
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Register(AccountData account)
        {
            manager.Login.OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();

        }

        private void OpenRegistrationForm()
        {
            manager.Driver.FindElement(By.XPath("(.//*[@class='widget-body']/*)[2]/*")).Click();
        }

        private void SubmitRegistration()
        {
            manager.Driver.FindElement(By.XPath("//*[@type='submit']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            manager.Driver.FindElement(By.Id("username")).SendKeys(account.Name);
            manager.Driver.FindElement(By.Id("email-field")).SendKeys(account.Email);
        }

       
    }
}
