using System;

namespace August
{
    /// <summary>
    /// This will define the accessibility for the command
    /// </summary>
    public enum FrameworkCommandPermission
    {
        /// <summary>
        /// Open for all
        /// </summary>
        Public, 
        /// <summary>
        /// Can only be call by other modules, not expose by user interface
        /// </summary>
        Protected, 
        /// <summary>
        /// Can only be call by self
        /// </summary>
        Private
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class FrameworkCommandAttribute : Attribute
    {
        public FrameworkCommandAttribute(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
    }
}
