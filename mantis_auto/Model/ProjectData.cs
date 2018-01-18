using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;


namespace mantis_auto
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        
        public ProjectData(string projectName)
        {
            this.ProjectName = projectName;
        }
        public ProjectData() { }

        [Column(Name = "name")]
        public string ProjectName { get; set; }

        [Column(Name = "status")]
        public string Status { get; set; }

        [Column(Name = "enabled")]
        public bool InheritCategories { get; set; }

        [Column(Name = "view_state")]
        public string ViewStatus { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; }

        public string Id { get; set; }


        public override bool Equals(object other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (this.GetType() != other.GetType())
                return false;

            return ProjectName == ((ProjectData)other).ProjectName;
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ProjectName == ((ProjectData)other).ProjectName;
        }

        public static List<ProjectData> GetDataFromDB()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from c in db.Projects select c).ToList();
            }
            
            
        }
    }
}
