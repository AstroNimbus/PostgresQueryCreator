using System;
using System.Text;
using static PostgresQueryCreator.Util.PQCHelpers;
namespace PostgresQueryCreator
{
    public class PQCWhere<T>
    {
        public string Column { get; set; }
        public string Comparer { get; set; }
        public T Value { get; private set; }

        public PQCWhere(string column, string comparer, T value)
        {
            Column = column;
            Comparer = comparer;
            Value = value;
        }

        public override string ToString()
        {
            return 
                ConvertToSafeColumn(Column) +
                Comparer + 
                ConvertToSafeString(Value);
        }
    }

}