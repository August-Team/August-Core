using August;
using AugustCore;
using System;
using System.Reflection;

namespace August
{
    /// <summary>
    /// Create a .txt reader for module <br />
    /// The data will update when file system changed is made. <br />
    /// The subclass must have attribute <seealso cref="FrameworkFilePathAttribute"></seealso> to mark the file path.
    /// </summary>
    /// <example>
    /// <code>
    /// [FrameworkFilePathAttribute("FileName", FileType.Data)]
    /// public TextIO : TextFileReader {
    ///     public static TextIO controller;
    ///     public TextIO() { controller = this; }
    ///     public override string DefaultData() => "Default text";
    /// }
    /// </code>
    /// </example>
    public abstract class TextFileReader : ICustomModuleEvent, IController
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
        /// Bot folder relative path to .txt file.
        /// </summary>
        public string path { protected set; get; }
        /// <summary>
        /// Check is this component is vaild
        /// </summary>
        public bool vaild { protected set; get; }

        /// <summary>
        /// Save txt data operation
        /// </summary>
        private Action<string, string> SaveAction;
        /// <summary>
        /// Load txt data operation
        /// </summary>
        private Func<string, string> LoadFunc;

        /// <summary>
        /// Properties of the actual string data
        /// </summary>
        public string data
        {
            set
            {
                SaveData(value);
            }
            get
            {
                return _data;
            }
        }
        private string _data;

        /// <summary>
        /// Initiaization for the text reader <br />
        /// It will vailated to class and set the use properties.
        /// </summary>
        public TextFileReader()
        {
            FrameworkFilePathAttribute ffpa = GetType().GetCustomAttribute<FrameworkFilePathAttribute>();
            if (ffpa == null)
            {
                vaild = false;
                return;
            }
            path = $"{GlobalPath.BotsConfigFolder}\\{ffpa.name}.txt";
            vaild = true;
        }

        /// <summary>
        /// Default string data
        /// </summary>
        public abstract string DefaultData();
        
        public void Save()
        {
            if (vaild)
                SaveAction.Invoke(path, _data);
        }
        public void SaveData(object t)
        {
            _data = t.ToString();
            Save();
        }
        public object Load()
        {
            if (vaild)
                return LoadFunc.Invoke(path);
            return null;
        }
        public void LoadData()
        {
            object r = Load();
            if (r != null)
            {
                _data = r.ToString();
            }
            else
            {
                string d = DefaultData();
                _data = d;
                Save();
            }
        }

        public virtual void Initialize() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void ModuleLoaded() { }
        public virtual void ModuleUnloading() { }
        public virtual void Exit() { }
    }
}
