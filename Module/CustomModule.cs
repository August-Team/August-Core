using August.Struct;
using AugustCore;
using System.IO;
using System.Reflection;

namespace August
{
    /// <summary>
    /// The header of the module <br />
    /// The module must at least one class inherit this in order to let framework identify.
    /// </summary>
    public abstract class CustomModule : ICustomModule, ICustomModuleEvent
    {
        public abstract ModuleHeader Info { get; }
        /// <summary>
        /// Framework context <br />
        /// Primary communication method with framework
        /// </summary>
        public FrameworkContext frameworkContext
        {
            get
            {
                return ModuleManager.GetFrameworkContext(GetType().Assembly);
            }
        }
        /// <summary>
        /// Bot prefix path
        /// </summary>
        private string m_PathRoot = string.Empty;

        /// <summary>
        /// Bot prefix path
        /// </summary>
        protected string BotRootPath
        {
            get
            {
                return m_PathRoot;
            }
        }
        /// <summary>
        /// Bot config path
        /// </summary>
        protected string ConfigPath
        {
            get
            {
                return Path.Combine(BotRootPath, GlobalPath.BotsConfigFolder);
            }
        }
        /// <summary>
        /// Bot data path
        /// </summary>
        protected string DataPath
        {
            get
            {
                return Path.Combine(BotRootPath, GlobalPath.BotsDataFolder);
            }
        }

        public virtual void Initialize() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void ModuleLoaded() { }
        public virtual void ModuleUnloading() { }
        public virtual void Exit() { }
    }
}
