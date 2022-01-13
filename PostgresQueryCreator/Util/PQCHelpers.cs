using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresQueryCreator.Util
{
    public static class PQCHelpers
    {
        public static string ConvertToSafeString(string value)
        {
            return SingleQuoteString(value);
        }
        public static string ConvertToSafeString(int value)
        {
            return value.ToString();
        }

        public static string ConvertToSafeString(double value)
        {
            return value.ToString();
        }
        public static string ConvertToSafeString(bool value)
        {
            return value.ToString();
        }
        public static string ConvertToSafeString(DateTime value)
        {
            return SingleQuoteString(value.ToString("O"));
        }
        public static string ConvertToSafeColumn(string column_name, string prefix = null)
        {
            string output = DoubleQuoteString(column_name);
            if (!string.IsNullOrEmpty(prefix))
            {
                output = prefix + "." + output;
            }
            return output;
        }
        public static string ConvertToSafeString<T>(T value)
        {
            throw new PQCException($"Can not convert {typeof(T)} to safe string");
        }
        private static string SingleQuoteString(string value)
        {
            return "'" + value + "'";
        }
        private static string DoubleQuoteString(string value)
        {
            return "\"" + value + "\"";
        }
    }
}
