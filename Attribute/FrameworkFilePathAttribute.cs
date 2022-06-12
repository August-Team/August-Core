using System;

namespace August
{
    /// <summary>
    /// Save type <br />
    /// It will effect save frequency
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// Only update to drive by menually call the save/load method
        /// </summary>
        Config,
        /// <summary>
        /// When background counter to zero and user has update the data then it will automatically call the store method
        /// </summary>
        Data,
        /// <summary>
        /// Each update will automatically call the store method
        /// </summary>
        ImportantData
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class FrameworkFilePathAttribute : Attribute
    {
        public FrameworkFilePathAttribute(string name, FileType type = FileType.Data)
        {
            this.name = name;
            this.type = type;
        }

        public string name { get; set; }
        public FileType type { get; set; }
    }
}
