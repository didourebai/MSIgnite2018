using System.Configuration;
using System.IO;
using System.Reflection;

namespace TravelGuideTunisia.Infrastructure.BaseContext
{
    public class ConfigurationFileCache
    {
        private readonly string _cacheFile;
        private readonly Assembly _definitionsAssembly;

        public ConfigurationFileCache(Assembly definitionsAssembly, string connectionStringName)
        {
            _definitionsAssembly = definitionsAssembly;
            var cacheDirectory = ConfigurationManager.AppSettings["nh_config_cache_file"];
            if (!Directory.Exists(cacheDirectory))
            {
                Directory.CreateDirectory(cacheDirectory);
            }
            _cacheFile = string.Format("{0}\\{1}_nh.cfg", cacheDirectory, connectionStringName);
        }

        public void DeleteCacheFile()
        {
            if (File.Exists(_cacheFile))
                File.Delete(_cacheFile);
        }

        public bool IsConfigurationFileValid
        {
            get
            {
                if (!File.Exists(_cacheFile) || _definitionsAssembly == null)
                    return false;

                var configInfo = new FileInfo(_cacheFile);


                var asmInfo = new FileInfo(_definitionsAssembly.Location);

                if (configInfo.Length < 5 * 1024)
                    return false;

                return configInfo.LastWriteTime >= asmInfo.LastWriteTime;
            }
        }

        public void SaveConfigurationToFile(Configuration configuration)
        {
            using (var file = File.Open(_cacheFile, FileMode.Create))
            {
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(file, configuration);
            }
        }

        public Configuration LoadConfigurationFromFile()
        {
            if (!IsConfigurationFileValid)
                return null;

            using (var file = File.Open(_cacheFile, FileMode.Open, FileAccess.Read))
            {
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return bf.Deserialize(file) as Configuration;
            }
        }
    }
}
