using System.Reflection;
using System.Threading.Tasks;

namespace August
{
    public abstract class CustomModuleComponent : ICustomModuleEvent
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

        public virtual Task Initialize() { return Task.CompletedTask; }
        public virtual Task Start() { return Task.CompletedTask; }
        public virtual Task Update() { return Task.CompletedTask; }
        public virtual Task ModuleLoaded() { return Task.CompletedTask; }
        public virtual Task ModuleUnloading() { return Task.CompletedTask; }
        public virtual Task Exit() { return Task.CompletedTask; }
    }
}
