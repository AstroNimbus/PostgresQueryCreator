using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static PostgresQueryCreator.Util.PQCHelpers;
namespace PostgresQueryCreator
{
    public class PQCQuery
    {
        public string Table { get; set; }
        public string Schema { get; set; }
        public List<string> ColumnNames { get; set; } = new List<string>();
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public bool Distinct { get; set; } = false;
        public PQCQuery(string table, string? schema, int? limit, int? offset, List<string> columnNames = null, bool distinct = false)
        {
            Table = table ?? throw new ArgumentNullException(nameof(table));
            Schema = schema;
            Limit = limit;
            Offset = offset;
            Distinct = distinct;
            if(columnNames != null)
            {
                ColumnNames = columnNames;
            }
        }
        public override string ToString()
        {
            StringBuilder QueryString = new StringBuilder();
            QueryString.Append("SELECT ");
            if (Distinct)
            {
                QueryString.Append("DISTINCT ");
            }
            if(ColumnNames.Count == 0)
            {
                QueryString.Append(" * ");
            }
            else
            {
                string.Join(", ", ColumnNames.Select(column => ConvertToSafeColumn(column)));
            }
            return QueryString.ToString();
        }
    }
}
