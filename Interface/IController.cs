namespace August
{
    public interface IController
    {
        /// <summary>
        /// Bot folder relative path to file.
        /// </summary>
        string path { get; }
        /// <summary>
        /// Check is this component is vaild
        /// </summary>
        bool vaild { get; }

        /// <summary>
        /// Save current stored data
        /// </summary>
        void Save();
        /// <summary>
        /// Set input data to current data and save it
        /// </summary>
        /// <param name="data">Input data</param>
        void SaveData(object data);
        /// <summary>
        /// Load data from target file
        /// </summary>
        /// <returns></returns>
        object Load();
        /// <summary>
        /// Load data from target file to data properties <br />
        /// If file does not exist, it will take default data to create one
        /// </summary>
        void LoadData();
    }
}
