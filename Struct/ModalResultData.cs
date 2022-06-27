using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;

namespace August
{
    /// <summary>
    /// Modal result data structure
    /// </summary>
    [Serializable]
    public class ModalResultData
    {
        /// <summary>
        /// Indexing the component by customID string
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ComponentData this[string index]
        {
            set
            {
                int i = Results.FindIndex(x => x.CustomId == index);
                if (i == -1) return;
                Results[i] = value;
            }
            get
            {
                int i = Results.FindIndex(x => x.CustomId == index);
                if (i == -1) return null;
                return Results[i];
            }
        }
        /// <summary>
        /// List of component data
        /// </summary>
        public List<ComponentData> Results = new List<ComponentData>();
        /// <summary>
        /// Interaction context
        /// </summary>
        public SocketInteraction interaction;
    }

    /// <summary>
    /// Modal component result data structure
    /// </summary>
    [Serializable]
    public class ComponentData
    {
        /// <summary>
        /// Component ID
        /// </summary>
        public string CustomId;
        /// <summary>
        /// Type of component
        /// </summary>
        public ComponentType Type;
        /// <summary>
        /// Multiple values result data
        /// </summary>
        public IReadOnlyCollection<string> Values;
        /// <summary>
        /// Primary result data
        /// </summary>
        public string Value;
    }
}
