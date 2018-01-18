using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_auto
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssure()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "27"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "short text",
                Description = "long text",
                Category = "General"
            };
            app.API.CreateNewIssue(account, project, issueData);

        }
    }
}
