using System;
using System.Collections.Generic;

namespace August
{
    /// <summary>
    /// Global debug message handler
    /// </summary>
    /// <example>
    /// <code>
    /// Debug.Log("System", "Output message", ConsoleColor.White);
    /// </code>
    /// </example>
    public sealed class Debug
    {
        private static IDebug[] debugs = new IDebug[0];

        /// <summary>
        /// Adding new logger
        /// </summary>
        /// <param name="i">Target logger</param>
        public static void AddILog(IDebug i)
        {
            List<IDebug> _debugs = new List<IDebug>(debugs);
            _debugs.Add(i);
            debugs = _debugs.ToArray();
        }

        /// <summary>
        /// Universal message print
        /// </summary>
        /// <param name="tag">Prefix</param>
        /// <param name="message">Message</param>
        /// <param name="color">Console Color</param>
        public static void Log(string tag, object message, ConsoleColor color = ConsoleColor.White)
        {
            foreach(IDebug i in debugs)
            {
                i.Log(tag, message, color);
            }
        }

        /// <summary>
        /// Bot message print
        /// </summary>
        /// <param name="botname">Bot name</param>
        /// <param name="tag">Prefix</param>
        /// <param name="message">Message</param>
        /// <param name="color">Console Color</param>
        public static void BotLog(string botname, string tag, object message, ConsoleColor color = ConsoleColor.White)
        {
            foreach (IDebug i in debugs)
            {
                i.BotLog(botname, tag, message, color);
            }
        }
    }
}
