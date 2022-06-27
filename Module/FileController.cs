using August;
using AugustCore;
using System;
using System.Reflection;

namespace August
{
    /// <summary>
    /// Create a controller for module data type <br />
    /// The data will update when file system changed is made. <br />
    /// The subclass must have attribute <seealso cref="FrameworkFilePathAttribute"></seealso> to mark the file path <br />
    /// <seealso cref="FrameworkFileFormatAttribute"></seealso> is optional for specified format
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    /// <example>
    /// <code>
    /// [FrameworkFilePathAttribute("FileName", FileType.Data)]
    /// public NewDataController : FileController &lt;NewData&gt; {
    ///     public static NewDataController controller;
    ///     public NewDataController() { controller = this; }
    ///     public override object DefaultData() => new NewData();
    /// }
    /// public class NewData {
    ///     public int value;
    /// }
    /// </code>
    /// </example>
    public abstract class FileController<T> : FileControllerBase
    {
        /// <summary>
        /// Actual data
        /// </summary>
        public T data
        {
            set
            {
                _data = value;
            }
            get
            {
                return _data;
            }
        }
        private T _data;

        /// <summary>
        /// Save data operation
        /// </summary>
        private Action<string, object> SaveAction;
        /// <summary>
        /// Load data operation
        /// </summary>
        private Func<string, Type, object> LoadFunc;

        /// <summary>
        /// Initiaization for the controller <br />
        /// It will vailated to class and set the use properties.
        /// </summary>
        public FileController()
        {
            FrameworkFilePathAttribute ffpa = GetType().GetCustomAttribute<FrameworkFilePathAttribute>();
            FrameworkFileFormatAttribute fffa = typeof(T).GetCustomAttribute<FrameworkFileFormatAttribute>();
            if (ffpa == null)
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
            path = $"{prefix}\\{ffpa.name}.{ext}";
            vaild = true;
        }

        /// <summary>
        /// Default data
        /// </summary>
        public override object DefaultData() => default(T);
        
        public override void Save()
        {
            if (vaild)
                SaveAction.Invoke(path, _data);
        }
        public override object Load()
        {
            if (vaild)
                return LoadFunc.Invoke(path, typeof(T));
            return null;
        }
        public override void SaveData(object data)
        {
            SaveData((T)data);
        }
        public void SaveData(T t)
        {
            _data = t;
            Save();
        }
        public override void LoadData()
        {
            T r = (T)Load();
            if (r != null)
            {
                _data = r;
            }
            else
            {
                object d = DefaultData();
                _data = (T)d;
                Save();
            }
        }
    }


    /// <summary>
    /// The base class of data controller <br />
    /// Contain basic functionality and properties for the controller
    /// </summary>
    public abstract class FileControllerBase : ICustomModuleEvent, IController
    {
        /// <summary>
        /// Framework context <br />
        /// Primary communication method with framework
        /// </summary>
        public FrameworkContext frameworkContext
        {
            get
            {
                return ModuleManager.GetFrameworkContext(GetType().Assembly);
            }
        }
        /// <summary>
        /// Type of the data
        /// </summary>
        public FileType type { protected set; get; }
        /// <summary>
        /// Format of the data
        /// </summary>
        public FileFormat format { protected set; get; }
        /// <summary>
        /// Bot folder relative path to file.
        /// </summary>
        public string path { protected set; get; }
        /// <summary>
        /// Check is this component is vaild
        /// </summary>
        public bool vaild { protected set; get; }

        /// <summary>
        /// Default data
        /// </summary>
        public abstract object DefaultData();

        public virtual void Save() { }
        public virtual void SaveData(object data) { }
        public virtual object Load() { return null; }
        public virtual void LoadData() { }

        public virtual void Initialize() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void ModuleLoaded() { }
        public virtual void ModuleUnloading() { }
        public virtual void Exit() { }
    }
}
