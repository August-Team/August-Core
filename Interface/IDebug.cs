﻿using System;

namespace August
{
    public interface IDebug
    {
        void Log(string tag, object message, ConsoleColor color);
        void BotLog(string tag, string botname, object message, ConsoleColor color);
    }
}
