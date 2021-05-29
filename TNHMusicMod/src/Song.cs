using Deli;
using Deli.VFS;
using UnityEngine;

namespace TNHMusicMod
{
    public struct Song 
    {
        public SongMetadata Info        { get; set; }
        public Mod          ModSource   { get; set; }
        public AudioClip    Audio       { get; set; }
    }
}