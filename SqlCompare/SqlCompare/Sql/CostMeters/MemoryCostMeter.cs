namespace SqlCompare.Meters
{
    public class MemoryCostMeter : CostMeter
    {
        public MemoryCostMeter(Connection conn) : base(conn) { }

        protected override string GetQueryText()
        {
            return $"select sum(bytes) from \"{conn.planTable}\" where statement_id = :query_id";
        }

    }
}
