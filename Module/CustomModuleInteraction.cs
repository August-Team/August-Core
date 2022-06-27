using Discord.Interactions;
using System.Reflection;

namespace August
{
    public abstract class CustomModuleInteraction : InteractionModuleBase<SocketInteractionContext>
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
    }
}
