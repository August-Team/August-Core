using Discord.Commands;
using System.Reflection;

namespace August
{
    public abstract class CustomModuleCommand : ModuleBase<SocketCommandContext>, ICustomModuleEvent
    {
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

        public virtual void Initialize() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void ModuleLoaded() { }
        public virtual void ModuleUnloading() { }
        public virtual void Exit() { }
    }
}
