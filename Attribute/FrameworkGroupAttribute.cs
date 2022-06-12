using August.Struct;
using System;

namespace August
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FrameworkGroupAttribute : Attribute
    {
        public FrameworkGroupAttribute(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
    }
}
