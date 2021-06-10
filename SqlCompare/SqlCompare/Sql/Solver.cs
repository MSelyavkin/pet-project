using SqlCompare.Meters;
using System.Collections.Generic;
using System.Linq;

namespace SqlCompare.Sql
{
    public class Solver
    {
        private CostMeter meter;
        private QueryExplainer explainer;

        public Solver(Connection conn, bool isSpeed)
        {
            if (isSpeed)
            {
                meter = new SpeedCostMeter(conn);
            }
            else
            {
                meter = new MemoryCostMeter(conn);
            }

            explainer = new QueryExplainer(conn);

        }


        public IEnumerable<int> Solve(IEnumerable<Query> queries, out int? winner)
        {
            explainer.ExplainQueries(queries);
            meter.GetCosts(queries);
            
            int winnersResult = queries.Where(q => q.Cost != - 1).Count() == 0 ?
                                -1 : queries.Where(q => q.Cost != -1).Select(q => q.Cost).Min();
            if (winnersResult == -1)
            {
                winner = null;
                return new List<int>();
            }

            List<int> result = new List<int>();
            for(int i = 0; i < queries.Count(); ++i)
            {
                if (queries.ElementAt(i).Cost == winnersResult)
                {
                    result.Add(i);
                }
            }
            winner = winnersResult;
            return result;
        }


    }
}
