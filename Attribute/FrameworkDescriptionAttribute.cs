using System;

namespace August
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class FrameworkDescriptionAttribute : Attribute
    {
        public FrameworkDescriptionAttribute(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
    }
}
