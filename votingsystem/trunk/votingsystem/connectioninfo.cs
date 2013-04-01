using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace votingsystem
{
    class connectioninfo
    {
        public OleDbConnection oleconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\w03s1762d\tech\TSA\MISC\remotedatabases\votesys.mdb");
    }
}
