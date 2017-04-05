using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Reflection;

namespace DBTool.Configuration
{
    [XmlInclude(typeof(XConfig))]
    [XmlRoot(Namespace = "",ElementName = "XConfig", IsNullable = false)]
    public class Config : XConfig
    {
        [XmlIgnore]
        public string ConfigPath { get; private set; }


        private  Config()
        {

        }

        public void SaveConfig(string newConfigPath, bool changeConfigPath = false)
        {
            var xser = new XmlSerializer(typeof(Config));
            using (var writer = new StreamWriter(newConfigPath))
                xser.Serialize(writer, this);
            if (changeConfigPath)
                ConfigPath = newConfigPath;
        }
        public void SaveConfig()
        {
            var xser = new XmlSerializer(typeof(Config));
            using (var writer = new StreamWriter(ConfigPath))
                xser.Serialize(writer, this);
        }

        public static Config ReadConfig(string configPath)
        {
            var xser = new XmlSerializer(typeof(Config));
            using (var reader = new StreamReader(configPath))
            {
                var config = (Config)xser.Deserialize(reader);
                config.ConfigPath = configPath;
                return config;
            }
        }
    }
}
