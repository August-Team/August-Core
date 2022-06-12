using System;
using System.Collections.Generic;

namespace August
{
    public sealed class Debug
    {
        private static IDebug[] debugs = new IDebug[0];

        public static void AddILog(IDebug i)
        {
            List<IDebug> _debugs = new List<IDebug>(debugs);
            _debugs.Add(i);
            debugs = _debugs.ToArray();
        }

        /* The discord framework log main function */
        public static void Log(string tag, object message, ConsoleColor color)
        {
            foreach(IDebug i in debugs)
            {
                i.Log(tag, message, color);
            }
        }

        public static void BotLog(string botname, string tag, object message, ConsoleColor color)
        {
            foreach (IDebug i in debugs)
            {
                i.BotLog(botname, tag, message, color);
            }
        }
    }
}
