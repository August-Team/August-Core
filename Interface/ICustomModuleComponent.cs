using System.Threading.Tasks;

namespace August
{
    public interface ICustomModuleEvent
    {
        /// <summary>
        /// Fire after modules is load
        /// </summary>
        Task Initialize();
        /// <summary>
        /// Fire after Initialize() called and framework finish initialization
        /// </summary>
        Task Start();
        /// <summary>
        /// Fire each framework update tick
        /// </summary>
        Task Update();
        /// <summary>
        /// Fire when module list is update
        /// </summary>
        Task ModuleLoaded();
        /// <summary>
        /// Fire when this module is unload
        /// </summary>
        Task ModuleUnloading();
        /// <summary>
        /// Fire when bot is exiting
        /// </summary>
        Task Exit();
    }
}
