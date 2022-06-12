using August.Struct;

namespace August
{
    public interface ICustomModule
    {
        ModuleHeader Info { get; }
        void Initialize();
        void Update();
    }
}
