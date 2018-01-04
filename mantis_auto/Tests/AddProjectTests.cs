using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_auto
{
    [TestFixture]
    class AddProjectTests : AuthTestBase
    {
        [Test]
        public void AddProjectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            //app.Login.LoginToTheSystem(account);
            app.LeftMenu.OpenManagement();
            app.Project.OpenManageProjects();
            List<ProjectData> oldProjects = app.Project.GetAllFromScreen();
            ProjectData prj = new ProjectData("ProjectTest53");
            Console.Out.WriteLine("element " + prj.ProjectName);

            app.Project.Create(prj);
            Console.Out.WriteLine("after project.create");
            oldProjects.Add(prj);
            app.LeftMenu.OpenManagement();
            app.Project.OpenManageProjects();
            
            List<ProjectData> newProjects = app.Project.GetAllFromScreen();
            oldProjects.Sort();
           foreach (ProjectData project in oldProjects)
                Console.Out.WriteLine(project.ProjectName);
            Console.Out.WriteLine("----------------------------");
            foreach(ProjectData project in newProjects)
                Console.Out.WriteLine(project.ProjectName);
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
