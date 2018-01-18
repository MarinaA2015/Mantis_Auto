using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_auto
{
    public class IssueData
    {
        public String Summary { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public ProjectData Project { get; set; }

        public IssueData() { }

    }
}
