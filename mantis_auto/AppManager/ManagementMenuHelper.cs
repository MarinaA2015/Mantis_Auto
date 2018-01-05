using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_auto
{
    class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void OpenManagement()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//*[@class='menu-text'][contains(text(),'Manage')]")).Click();
            //driver.FindElement(By.TagName("span")).Text("Manage");
        }
    }
}
