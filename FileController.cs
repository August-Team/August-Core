using August.Setup;
using System;
using System.Reflection;

namespace August
{
    public abstract class FileController<T> : FileControllerBase
    {
        public T data { get; set; }
        private Action<string, object> SaveAction;
        private Func<string, Type, object> LoadFunc;

        public FileController()
        {
            FrameworkFilePathAttribute ffpa = typeof(T).GetCustomAttribute<FrameworkFilePathAttribute>();
            FrameworkFileFormatAttribute fffa = typeof(T).GetCustomAttribute<FrameworkFileFormatAttribute>();
            if(ffpa == null)
            {
                vaild = false;
                return;
            }
            format = fffa == null ? FileFormat.Json : fffa.type;
            string ext = string.Empty;
            switch (format)
            {
                case FileFormat.Binary:
                    ext = "data";
                    break;
                case FileFormat.Bson:
                    ext = "bson";
                    break;
                case FileFormat.Json:
                    ext = "json";
                    break;
            }
            type = ffpa.type;
            string prefix = string.Empty;
            switch (type)
            {
                case FileType.Config:
                    prefix = GlobalPath.BotsConfigFolder;
                    break;
                case FileType.Data:
                case FileType.ImportantData:
                    prefix = GlobalPath.BotsDataFolder;
                    break;
            }
            path = $"{prefix}/{ffpa.name}.{ext}";
            vaild = true;
        }

        public override object DefaultData() => default(T);
        public void Save() => SaveAction.Invoke(path, data);
        public object Load() => LoadFunc.Invoke(path, typeof(T));

        public void SaveData(T t)
        {
            data = t;
            Save();
        }
        public void LoadData()
        {
            T r = (T)Load();
            if (r != null)
            {
                data = r;
            }
            else
            {
                object d = DefaultData();
                data = (T)d;
                Save();
            }
        }
    }

    public abstract class FileControllerBase
    {
        public FileType type { protected set; get; }
        public FileFormat format { protected set; get; }
        public string path { protected set; get; }
        public bool vaild { protected set; get; }

        public abstract object DefaultData();
    }
}
