using Oracle.ManagedDataAccess.Client;
using SqlCompare.Sql;
using System;
using System.Collections.Generic;

namespace SqlCompare
{
    public abstract class CostMeter
    {
        protected readonly Connection conn;


        public CostMeter(Connection conn)
        {
            this.conn = conn;
        }

        protected abstract string GetQueryText();

        protected void GetCost(Query query)
        {
            using (OracleConnection connection = new OracleConnection(conn.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    var p = cmd.Parameters;
                    p.Add("query_id", query.Id);

                    cmd.CommandText = GetQueryText();

                    query.Cost = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    query.Cost = -1;
                }

            }
        }

        public void GetCosts(IEnumerable<Query> queries)
        {
            foreach(var q in queries)
            {
                if(q.Cost != -1)
                {
                    GetCost(q);
                }
            }   
        }

    }
}
