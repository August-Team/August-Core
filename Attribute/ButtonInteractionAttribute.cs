using System;

namespace August
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonInteractionAttribute : Attribute
    {
        public ButtonInteractionAttribute(string id)
        {
            this.CustomId = id;
        }

        public string CustomId { set; get; }
    }
}
