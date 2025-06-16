using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetLib
{
    public class DbExecutor
    {
        private MainConnector connector;
        public DbExecutor(MainConnector connector)
        {
            this.connector = connector;
        }

        public DataTable SelectAll(string table)
        {
            var dt = new DataTable();
            var selectcommandtext = "select * from " + table;
            var adapter = new SqlDataAdapter(
              selectcommandtext,
              connector.GetConnection()
            );
            var ds = new DataSet();
            adapter.Fill(ds);

            //return dt;
            return ds.Tables[0];
        }
    }
}
