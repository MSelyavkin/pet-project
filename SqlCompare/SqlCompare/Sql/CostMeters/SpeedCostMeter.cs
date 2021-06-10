namespace SqlCompare
{
    public class SpeedCostMeter : CostMeter
    {
        public SpeedCostMeter(Connection conn) : base(conn) { }

        protected override string GetQueryText()
        {
            return $"select sum(cost) from \"{conn.planTable}\" where statement_id = :query_id";
        }
    }
}
