using August.Struct;

namespace August
{
    public interface ICustomModule
    {
        /// <summary>
        /// Module information
        /// </summary>
        ModuleHeader Info { get; }
    }
}
