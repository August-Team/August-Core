using System;
using System.Reflection;

namespace August
{
    public sealed class AugustFunc : IDisposable
    {
        object Host;
        MethodInfo Info;

        public bool Vaild => Host != null && Info != null;

        public AugustFunc(object host, MethodInfo info)
        {
            Host = host;
            Info = info;
        }

        public void Dispose()
        {
            Host = null;
            Info = null;
        }

        public object Invoke(params object[] arguments)
        {
            return Info.Invoke(Host, arguments);
        }
    }
}
