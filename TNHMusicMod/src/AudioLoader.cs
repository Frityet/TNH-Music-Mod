using System;
using System.Collections;
using System.Collections.Generic;
using Deli;
using Deli.Runtime;
using Deli.VFS;
using UnityEngine;

namespace TNHMusicMod
{
    public class AudioLoader
    {
        internal List<Song> LoadedSongs = new();
        
        public IEnumerator LoadAssets(RuntimeStage stage, Mod mod, IHandle rawfile)
        {
            if (rawfile is not IFileHandle file) throw new Exception($"FILE {rawfile.Path} IN {mod.Info.Name} IS NOT VALID!");
            var song = new Song();
            
            
            yield break;
        }
    }
}