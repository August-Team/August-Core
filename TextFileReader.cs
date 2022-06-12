using August.Setup;
using System;
using System.Reflection;

namespace August
{
    public abstract class TextFileReader
    {
        public string path { protected set; get; }
        public bool vaild { protected set; get; }

        private Action<string, string> SaveAction;
        private Func<string, string> LoadFunc;

        public string data;

        public TextFileReader()
        {
            FrameworkFilePathAttribute ffpa = GetType().GetCustomAttribute<FrameworkFilePathAttribute>();
            if (ffpa == null)
            {
                vaild = false;
                return;
            }
            path = $"{GlobalPath.BotsConfigFolder}/{ffpa.name}.txt";
            vaild = true;
        }

        public abstract string DefaultData();
        public void Save() => SaveAction.Invoke(path, data);
        public string Load() => LoadFunc.Invoke(path);

        public void SaveData(string t)
        {
            data = t;
            Save();
        }
        public void LoadData()
        {
            string r = Load();
            if (r != null)
            {
                data = r;
            }
            else
            {
                string d = DefaultData();
                data = d;
                Save();
            }
        }
    }
}
