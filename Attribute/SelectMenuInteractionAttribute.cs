using System;

namespace August
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SelectMenuInteractionAttribute : Attribute
    {
        public SelectMenuInteractionAttribute(string id)
        {
            this.CustomId = id;
        }

        public string CustomId { set; get; }
    }
}
