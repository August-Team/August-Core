using August.Setup;
using System.IO;

namespace August
{ 
    public abstract class CustomModule : ICustomModule
    {
        protected string m_PathRoot { private set; get; }
        public abstract Struct.ModuleHeader Info { get; }
        public FrameworkContext frameworkContext { set; get; }

        protected void SetBotRoot(string pathroot)
        {
            m_PathRoot = pathroot;
        }

        protected string BotRootPath
        {
            get
            {
                return m_PathRoot;
            }
        }
        protected string ModPath
        {
            get
            {
                return Path.Combine(BotRootPath, GlobalPath.BotsModFolder);
            }
        }
        protected string ConfigPath
        {
            get
            {
                return Path.Combine(BotRootPath, GlobalPath.BotsConfigFolder);
            }
        }
        protected string DataPath
        {
            get
            {
                return Path.Combine(BotRootPath, GlobalPath.BotsDataFolder);
            }
        }

        public virtual void Initialize() { }
        public virtual void Update() { }
    }
}
