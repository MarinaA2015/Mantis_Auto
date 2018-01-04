using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_auto
{  
    class MantisDB : LinqToDB.Data.DataConnection
    {
        public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }
    }
}
