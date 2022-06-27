using Discord.WebSocket;
using System;

namespace August
{
    [Serializable]
    public class SelectMenuDataResult
    {
        /// <summary>
        /// Interaction context
        /// </summary>
        public SocketInteraction interaction;
        public ComponentData data;
    }
}
