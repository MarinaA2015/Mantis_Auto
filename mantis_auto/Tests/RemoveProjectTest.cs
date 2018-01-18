using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace mantis_auto
{
    [TestFixture]
    class RemoveProjectTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {
            app.LeftMenu.OpenManagement();
            app.Project.OpenManageProjects();
            List<ProjectData> oldProjects = ProjectData.GetDataFromDB();
            
            if (oldProjects.Count == 0)
                app.Project.Create(new ProjectData("_First Project"));
            ProjectData removedPrj = oldProjects[0];
            app.Project.DeleteProject(removedPrj);
            oldProjects.Remove(removedPrj);
            app.LeftMenu.OpenManagement();
            app.Project.OpenManageProjects();
            List<ProjectData> newProjects = ProjectData.GetDataFromDB();
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void RemoveProjectUsingAPITest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            app.LeftMenu.OpenManagement();
            app.Project.OpenManageProjects();
            List<ProjectData> oldProjects = app.API.GetAllProjects(account);
            if (oldProjects.Count == 0)
                app.API.CreateNewProject(account,new ProjectData("_First Project"));
            ProjectData removedPrj = oldProjects[0];
            app.Project.DeleteProject(removedPrj);
            oldProjects.Remove(removedPrj);
            app.LeftMenu.OpenManagement();
            app.Project.OpenManageProjects();
            List<ProjectData> newProjects = app.API.GetAllProjects(account);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
