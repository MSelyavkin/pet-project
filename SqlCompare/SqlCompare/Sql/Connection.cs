using System;
using Oracle.ManagedDataAccess.Client;

namespace SqlCompare
{
    public class Connection
    {
        public bool IsValid
        {
            get => isValid;
        }

        private bool isValid;
        public readonly string host;
        public readonly string port;
        public readonly string service;
        public readonly string user;
        public readonly string password;
        public readonly string planTable;

        public string ConnectionString { get; private set; }


        public Connection(
            string host, string port, 
            string service, string user, 
            string password, string planTable
            )
        {
            isValid = false;
            this.host = host;
            this.port = port;
            this.service = service;
            this.user = user;
            this.password = password;
            this.planTable = planTable.ToUpper();
            ConnectionString = SqlUtils.GetConnectionString(host, port, service, user, password);
               
        }


        public string Connect(bool createPlanTable)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "select 1 from all_tables where table_name = :name"; 
                    
                    var p = cmd.Parameters;
                    p.Add("name", planTable);

                    var reader = cmd.ExecuteReader();
                    isValid = reader.HasRows;
                    if (isValid)
                    {
                        return "Успешно";
                    }
                    else
                    {
                        if (createPlanTable)
                        {
                            CreatePlanTable();
                            isValid = true;
                            return "Успешно";
                        }
                        return $"В схеме нет таблицы {planTable} (Будет создана автоматически при подключении)";
                    }
                    
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private void CreatePlanTable()
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlUtils.GetPlanTableScript(planTable);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
