using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace PostgresQueryCreator.Util
{
    public class PqcStringBuilder
    {
        private readonly List<string> StringList = new List<string>();
        public PqcStringBuilder() { }
        public PqcStringBuilder(string value) { StringList.Add(value); }
        public PqcStringBuilder Append(string stringToAppend)
        {
            StringList.Add(stringToAppend);
            return this;
        }
        public static implicit operator string(PqcStringBuilder d) => d.ToString();
        public override string ToString()
        {
            return string.Join(" ", StringList);
        }
    }
}
