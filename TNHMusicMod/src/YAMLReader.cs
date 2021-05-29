using System;
using System.IO;
using Deli.VFS;
using Deli.VFS.Disk;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TNHMusicMod
{
    // ReSharper disable once InconsistentNaming //Yaml looks weird, YAML is better
    public class YAMLReader<T>
    {
        public static T ReadFile(IFileHandle rawfile)
        {
            TNHMusicMod.Logging.LogDebug($"Reading file {rawfile.Name}");
            if (rawfile is not IDiskHandle file) throw new Exception($"{rawfile} IS NOT A VALID FILE");
            
            var raw = File.ReadAllLines(file.PathOnDisk).ToString();
        
            
            var deserialiser = new DeserializerBuilder()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .Build();


            try
            {
                TNHMusicMod.Logging.LogDebug("Deserialising");
                return deserialiser.Deserialize<T>(raw);
            }
            catch (Exception e)
            {
                throw new Exception($"{rawfile} IS NOT VALID YAML!\n{e}");
            }
        }
    }
}