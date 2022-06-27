namespace August
{
    public interface ICustomModuleEvent
    {
        /// <summary>
        /// Fire after modules is load
        /// </summary>
        void Initialize();
        /// <summary>
        /// Fire after Initialize() called and framework finish initialization
        /// </summary>
        void Start();
        /// <summary>
        /// Fire each framework update tick
        /// </summary>
        void Update();
        /// <summary>
        /// Fire when module list is update
        /// </summary>
        void ModuleLoaded();
        /// <summary>
        /// Fire when this module is unload
        /// </summary>
        void ModuleUnloading();
        /// <summary>
        /// Fire when bot is exiting
        /// </summary>
        void Exit();
    }
}
