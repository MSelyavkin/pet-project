using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Text;

namespace SqlCompare.Sql
{
    public class QueryExplainer
    {
        protected readonly Connection conn;

        public QueryExplainer(Connection conn)
        {
            this.conn = conn;
        }

        private void ClearCache()
        {
            using(OracleConnection connection = new OracleConnection(conn.ConnectionString))
            {
                connection.Open();
                OracleCommand clearCache = connection.CreateCommand();
                clearCache.CommandText = "ALTER SYSTEM FLUSH BUFFER_CACHE";
                clearCache.ExecuteNonQuery();
            }
        }

        private void ClearSharedPool()
        {
            using (OracleConnection connection = new OracleConnection(conn.ConnectionString))
            {
                connection.Open();
                OracleCommand clearSharedPool = connection.CreateCommand();
                clearSharedPool.CommandText = "ALTER SYSTEM FLUSH SHARED_POOL";
                clearSharedPool.ExecuteNonQuery();
            }
        }

        private string GetExplainPlanText(Query query)
        {
            return
                new StringBuilder()
                .AppendLine("EXPLAIN PLAN ")
                .AppendLine($"SET STATEMENT_ID = '{query.Id}' ")
                .AppendLine($"INTO \"{conn.planTable}\" FOR ")
                .Append(query.Text)
                .ToString();
        }

        private void ExplainQuery(Query query)
        {
            ClearCache();
            ClearSharedPool();

            using (OracleConnection connection = new OracleConnection(conn.ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleCommand explain = connection.CreateCommand();
                    explain.CommandText = GetExplainPlanText(query);
                    explain.ExecuteNonQuery();
                }
                catch
                {
                    query.Cost = -1;
                }

            }
        }

        public void ExplainQueries(IEnumerable<Query> queries)
        {
            foreach (var q in queries)
            {
                ExplainQuery(q);
            }
        }
    }
}
