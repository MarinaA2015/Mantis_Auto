using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace mantis_auto
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

       
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();

            Registration = new RegistrationHelper(this);
            Login = new LoginHelper(this);
            LeftMenu = new ManagementMenuHelper(this);
            Project = new ProjectHelper(this);

           
        }
         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; private set; }
        internal LoginHelper Login { get; private set; }
        internal ManagementMenuHelper LeftMenu { get; private set; }
        internal ProjectHelper Project { get; private set; }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                
                newInstance.driver.Url = "http://localhost/mantisbt-2.9.0/mantisbt-2.9.0/login_page.php";
                app.Value = newInstance;
               

            }
            

            return app.Value;
        }
    }
}
