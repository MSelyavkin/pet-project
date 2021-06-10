using System;

namespace SqlCompare.Sql
{
    public class Query
    {
        public string Id { get; init; }
        public string Text { get; init; }
        public int Cost { get; set; }

        public Query(string text)
        {
            Text = SqlUtils.TrimSemicolon(text);
            Id = Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
