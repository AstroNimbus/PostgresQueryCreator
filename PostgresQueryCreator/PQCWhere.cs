using System;
using System.Text;
using static PostgresQueryCreator.Util.PqcHelpers;
namespace PostgresQueryCreator
{
    public class PqcWhere<T>
    {
        public string Column { get; set; }
        public string Comparer { get; set; }
        public T Value { get; private set; }

        public PqcWhere(string column, string comparer, T value)
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