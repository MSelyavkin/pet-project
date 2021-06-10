using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCompare
{
    public static class SqlUtils
    {
        public static string TrimSemicolon(string queryText)
        {
            if(queryText.EndsWith(";"))
            {
                return queryText.Substring(0, queryText.Length - 1);
            }

            return queryText;
        }

        public static string GetConnectionString(
            string host, string port, string service, string user, string password)
        {
            return
                new StringBuilder()
                .AppendLine("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)")
                .AppendLine($"(HOST={host})(PORT={port})))(CONNECT_DATA=(SERVICE_NAME={service})))")
                .Append($";User Id={user};Password={password};")
                .ToString();
        }


        public static string GetPlanTableScript(string planTableName)
        {
            return
                new StringBuilder()
                .AppendLine($"create table \"{planTableName}\" sharing=none (")
                .AppendLine("statement_id       varchar2(30),")
                .AppendLine("plan_id            number,")
                .AppendLine("timestamp          date,")
                .AppendLine("remarks            varchar2(4000),")
                .AppendLine("operation          varchar2(30),")
                .AppendLine("options            varchar2(255),")
                .AppendLine("object_node        varchar2(128),")
                .AppendLine("object_owner       varchar2(128),")
                .AppendLine("object_name        varchar2(128),")
                .AppendLine("object_alias       varchar2(261),")
                .AppendLine("object_instance    numeric,")
                .AppendLine("object_type        varchar2(30),")
                .AppendLine("optimizer          varchar2(255),")
                .AppendLine("search_columns     number,")
                .AppendLine("id                 numeric,")
                .AppendLine("parent_id          numeric,")
                .AppendLine("depth              numeric,")
                .AppendLine("position           numeric,")
                .AppendLine("cost               numeric,")
                .AppendLine("cardinality        numeric,")
                .AppendLine("bytes              numeric,")
                .AppendLine("other_tag          varchar2(255),")
                .AppendLine("partition_start    varchar2(255),")
                .AppendLine("partition_stop     varchar2(255),")
                .AppendLine("partition_id       numeric,")
                .AppendLine("other              long,")
                .AppendLine("distribution       varchar2(30),")
                .AppendLine("cpu_cost           numeric,")
                .AppendLine("io_cost            numeric,")
                .AppendLine("temp_space         numeric,")
                .AppendLine("access_predicates  varchar2(4000),")
                .AppendLine("filter_predicates  varchar2(4000),")
                .AppendLine("projection         varchar2(4000),")
                .AppendLine("time               numeric,")
                .AppendLine("qblock_name        varchar2(128),")
                .AppendLine("other_xml          clob")
                .AppendLine(")")
                .ToString();

        }

    }
}
