using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_auto
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }
        Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
           // Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProjects(AccountData account)
        {
           // Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            List<ProjectData> allProjects = new List<ProjectData>();
            Mantis.ProjectData[] projectsUsingAPI = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach(Mantis.ProjectData prj in projectsUsingAPI)
            {
                allProjects.Add(new ProjectData(prj.name));
            }
            return allProjects;
        }

        internal void CreateNewProject(AccountData account,ProjectData project)
        {
           // Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData prjMantis = new Mantis.ProjectData();
            prjMantis.name = project.ProjectName;
            client.mc_project_add(account.Name, account.Password, prjMantis);
        }
    }
}
