using System;
using System.Reflection;

namespace August
{
    public sealed class AugustAction : IDisposable
    {
        object Host;
        MethodInfo Info;

        public bool Vaild => Host != null && Info != null;

        public AugustAction(object host, MethodInfo info)
        {
            Host = host;
            Info = info;
        }

        public void Dispose()
        {
            Host = null;
            Info = null;
        }

        public void Invoke(object[] arguments)
        {
            Info.Invoke(Host, arguments);
        }
    }
}
