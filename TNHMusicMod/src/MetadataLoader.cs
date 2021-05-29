using System;
using System.Collections;
using System.Collections.Generic;
using Deli;
using Deli.Runtime;
using Deli.VFS;

namespace TNHMusicMod
{
    public class MetadataLoader
    {
        public Dictionary<Mod, SongMetadata> LoadedMetadata { get; private set; } = new();
        
        public IEnumerator LoadAssets(RuntimeStage stage, Mod mod, IHandle rawfile)
        {
            if (rawfile is not IFileHandle file) throw new Exception($"FILE {rawfile.Path} IN {mod.Info.Name} IS NOT VALID!");
    
            TNHMusicMod.Logging.LogDebug($"Loading asset {file.Name}");
            
            SongMetadata yaml;
            yield return yaml = stage.ImmediateReaders.Get<SongMetadata>().Invoke(file);
            
            TNHMusicMod.Logging.LogDebug("Got YAML");
            
            LoadedMetadata.Add(mod, yaml);
        }
    }
}