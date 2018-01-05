using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_auto
{
    class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Create(ProjectData prj)
        {
            OpenManageProjects();
            InitProjectCreation();
            FillFieldsOfProject(prj);
            SaveProject();
        }

        public ProjectHelper OpenManageProjects()
        {
            //driver.FindElement(By.XPath(".//a[contains(text(),'Manage Projects')]")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//a[.='Manage Projects']")).Click();
            return this;
        }

        internal ProjectHelper DeleteProject(ProjectData prj)
        {
            OpenProject(prj.ProjectName);
            PressDeleteProjectButton();
            SubmitDeletion();
            return this;
        }

        private void SubmitDeletion()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input[value='Delete Project'][ type='submit']")).Click();
        }

        private void PressDeleteProjectButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input[value='Delete Project'][ type='submit']")).Click();
        }

        private void OpenProject(string projectName)
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//tbody//a[.='" + projectName + "']")).Click();
        }

        private ProjectHelper InitProjectCreation()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'Create New Project')]")).Click();
            return this;
        }
        
        public List<ProjectData> GetAllFromScreen()
        {
            System.Threading.Thread.Sleep(1000);
            //ICollection<IWebElement> elements = manager.Driver.FindElements(By.XPath("(//*[@id='main - container']//tbody)[1]//tr"));
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tbody>tr>td>a"));
            ;

            List<ProjectData> res = new List<ProjectData>();
            Console.Out.WriteLine("------------elements-------------"+elements.Count);
            foreach(IWebElement element in elements)
            {
                //Console.Out.WriteLine("element"+element.Text);
                res.Add(new ProjectData(element.Text));
            }
            return res;
        }

        private ProjectHelper FillFieldsOfProject(ProjectData prj)
        {
            //Type(By.Name("name"), prj.ProjectName);
            driver.FindElement(By.Name("name")).SendKeys(prj.ProjectName);
            return this;
        }
        private ProjectHelper SaveProject()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            return this;
        }
    }
}
