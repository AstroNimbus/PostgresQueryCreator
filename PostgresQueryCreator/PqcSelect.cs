using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static PostgresQueryCreator.Util.PqcHelpers;
using PostgresQueryCreator.Util;

namespace PostgresQueryCreator
{
    public class PqcSelect
    {
        public string Table { get; set; }
        public string Schema { get; set; }
        public List<string> ColumnNames { get; set; } = new List<string>();
        public List<PqcWhere> Wheres { get; set; } = new List<PqcWhere>();
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public bool Distinct { get; set; } = false;
        public PqcSelect(string table, int? limit, int? offset, List<PqcWhere> pqcWheres = null, List<string> columnNames = null, string schema = null, bool distinct = false)
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
            if (pqcWheres != null)
            {
                Wheres = pqcWheres;
            }
        }
        public override string ToString()
        {
            PqcStringBuilder QueryString = new PqcStringBuilder();
            QueryString.Append("SELECT");
            if (Distinct)
            {
                QueryString.Append("DISTINCT");
            }
            if(ColumnNames.Count == 0)
            {
                QueryString.Append(" * ");
            }
            else
            {
                QueryString.Append(
                    string.Join(", ", ColumnNames.Select(column => ConvertToSafeColumn(column)))
                );
            }
            QueryString.Append($"FROM");
            if (!string.IsNullOrEmpty(Schema))
            {
                QueryString.Append($"{Schema}.{Table}");
            }
            else
            {
                QueryString.Append($"{Table}");

            }

            if (Wheres.Count != 0)
            {
                QueryString.Append("WHERE"); 
                QueryString.Append(
                    string.Join("AND ", Wheres.Select(where => where.ToString()))
                );
            }
            if(Limit != null)
            {
                QueryString.Append($"LIMIT {Limit}");
            }
            if (Offset != null)
            {
                QueryString.Append($"OFFSET {Offset}");
            }
            return QueryString.ToString();
        }
    }
}
