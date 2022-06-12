using System;

namespace August
{
    public sealed class FrameworkContext
    {
        private System.Func<string, string, AugustAction> GetFrameworkAction;
        private System.Func<string, string, Type, AugustFunc> GetFrameworkFunc;

        public FrameworkContext(Func<string, string, AugustAction> getFrameworkAction, Func<string, string, Type, AugustFunc> getFrameworkFunc)
        {
            GetFrameworkAction = getFrameworkAction;
            GetFrameworkFunc = getFrameworkFunc;
        }

        public AugustFunc GetCommandFunc<T>(string module, string command)
        {
            return GetFrameworkFunc.Invoke(module, command, typeof(T));
        }

        public AugustAction GetCommandAction(string module, string command)
        {
            return GetFrameworkAction.Invoke(module, command);
        }

        public bool InvokeCommandFunc<T>(string module, string command, object[] arguments, out T result)
        {
            AugustFunc n = GetFrameworkFunc.Invoke(module, command, typeof(T));
            if(n != null)
            {
                result = (T)n.Invoke(arguments);
                return true;
            }
            result = default(T);
            return false;
        }

        public bool InvokeCommandAction(string module, string command, object[] arguments)
        {
            AugustAction n = GetFrameworkAction.Invoke(module, command);
            if (n != null)
            {
                n.Invoke(arguments);
                return true;
            }
            return false;
        }
    }
}
