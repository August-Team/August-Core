using System;

namespace August.Setup
{
    [Serializable]
    public struct Properties
    {
        public int UpdateMilliseconds;
        public string EmbedColor;

        public static Properties Default
        {
            get
            {
                return new Properties()
                {
                    UpdateMilliseconds = 10000,
                    EmbedColor = "255:255:255"
            };
            }
        }
    }
}
