using System;

namespace August
{
    /// <summary>
    /// Save format <br />
    /// It will effect save data structure
    /// </summary>
    public enum FileFormat
    {
        Binary,
        Bson,
        Json,
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class FrameworkFileFormatAttribute : Attribute
    {
        public FrameworkFileFormatAttribute(FileFormat type = FileFormat.Json)
        {
            this.type = type;
        }

        public FileFormat type { get; set; }
    }
}
