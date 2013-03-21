using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Dresscode
{
    class globals
    {
        public OleDbConnection oleconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\w03s1762d\tech\TSA\dresscode\dc.mdb;Jet OLEDB:Database Password=Braves2013");
        //public OleDbConnection oleconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\DevPump\Documents\Visual Studio 2012\Projects\Dresscode\Dresscode\dc.mdb;Jet OLEDB:Database Password=Braves2013");
    }
}
