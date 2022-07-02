using System;
using System.Text.RegularExpressions;

namespace August
{
    /// <summary>
    /// August log behaviour,<br />
    /// Log system will print the one without using tag filter first.
    /// </summary>
    public interface IDebug
    {
        /// <summary>
        /// Block the log when tag filter regex is match <br />
        /// This means only print once
        /// </summary>
        bool block { get; }
        /// <summary>
        /// Specified log tag filter
        /// </summary>
        bool useFilter { get; }
        /// <summary>
        /// Filter regex, try to match with tag string with it
        /// </summary>
        Regex tagFilter { get; }
        /// <summary>
        /// Normal log color
        /// </summary>
        ConsoleColor logColor { get; }
        /// <summary>
        /// Warning log color
        /// </summary>
        ConsoleColor warningColor { get; }
        /// <summary>
        /// Error log color
        /// </summary>
        ConsoleColor errorColor { get; }


        /// <summary>
        /// Universal print message
        /// </summary>
        void Log(string tag, object message);
        /// <summary>
        /// Universal print message
        /// </summary>
        void Log(string tag, object message, ConsoleColor color);
        /// <summary>
        /// Universal print warning message
        /// </summary>
        void WarningLog(string tag, object message);
        /// <summary>
        /// Universal print error message
        /// </summary>
        void ErrorLog(string tag, object message);
    }
}
