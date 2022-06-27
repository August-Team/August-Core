using System;

namespace August
{
    public sealed class FrameworkContext
    {
        private readonly Func<Type, object> GetFrameworkType;
        private readonly Func<string, string, AugustAction> GetFrameworkAction;
        private readonly Func<string, string, Type, AugustFunc> GetFrameworkFunc;

        public FrameworkContext(Func<Type, object> getClass, Func<string, string, AugustAction> getFrameworkAction, Func<string, string, Type, AugustFunc> getFrameworkFunc)
        {
            GetFrameworkType = getClass;
            GetFrameworkAction = getFrameworkAction;
            GetFrameworkFunc = getFrameworkFunc;
        }

        public AugustFunc GetCommandFunc<T>(string module, string group, string command)
        {
            return GetCommandFunc<T>(module, $"{group} {command}");
        }

        public AugustFunc GetCommandFunc<T>(string module, string fullcommand)
        {
            return GetFrameworkFunc.Invoke(module, fullcommand, typeof(T));
        }

        public AugustAction GetCommandAction(string module, string group, string command)
        {
            return GetCommandAction(module, $"{group} {command}");
        }

        public AugustAction GetCommandAction(string module, string fullcommand)
        {
            return GetFrameworkAction.Invoke(module, fullcommand);
        }

        /// <summary>
        /// Get current assembly class type instance
        /// </summary>
        /// <typeparam name="T">Type target</typeparam>
        public T GetInstanceClass<T>() where T : class
        {
            return (T)GetFrameworkType.Invoke(typeof(T));
        }

        /// <summary>
        /// Get current assembly class type instance
        /// </summary>
        /// <typeparam name="type">Type target</typeparam>
        public object GetInstanceClass(Type type)
        {
            return GetFrameworkType.Invoke(type);
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
