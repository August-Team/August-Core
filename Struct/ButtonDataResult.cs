using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace August
{
    [Serializable]
    public class ButtonDataResult
    {
        /// <summary>
        /// Interaction context
        /// </summary>
        public SocketInteraction interaction;
        public ComponentData data;
    }
}
