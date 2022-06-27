using System.Collections.Generic;
using System.Reflection;

namespace August
{
    public static class ModuleManager
    {
        private static Dictionary<Assembly, FrameworkContext> moduleDict = new Dictionary<Assembly, FrameworkContext>();

        public static FrameworkContext GetFrameworkContext(Assembly key) => moduleDict[key];

        public static void Add(Assembly assembly, FrameworkContext context)
        {
            moduleDict.Add(assembly, context);
        }

        public static void Remove(Assembly assembly)
        {
            moduleDict.Remove(assembly);
        }
    }
}
