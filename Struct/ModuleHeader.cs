using System;

namespace August.Struct
{
    /// <summary>
    /// Module header will help framework to identify target module
    /// </summary>
    [Serializable]
    public struct ModuleHeader
    {
        /// <summary>
        /// Name of the module
        /// </summary>
        public string m_ModuleName;
        /// <summary>
        /// Description of the module
        /// </summary>
        public string m_ModuleDescription;
        /// <summary>
        /// Command of the module
        /// </summary>
        public string m_CommandPrefix;
        /// <summary>
        /// Major version
        /// </summary>
        public int m_VersionMajor;
        /// <summary>
        /// Minor version
        /// </summary>
        public int m_VersionMinor;
        /// <summary>
        /// Detail version
        /// </summary>
        public string m_VersionDetail;

        /// <summary>
        /// The version string
        /// </summary>
        public string Version => $"{m_VersionMajor}.{m_VersionMinor}.{m_VersionDetail}";
    }
}
