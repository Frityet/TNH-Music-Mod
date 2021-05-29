using System;
using BepInEx.Logging;
using Deli;
using Deli.Runtime;
using Deli.Setup;
using UnityEngine.SceneManagement;

namespace TNHMusicMod
{
	// ReSharper disable once InconsistentNaming //stfu bitch
	public class TNHMusicMod : DeliBehaviour
	{
		internal AudioLoader AudioLoader = new AudioLoader();
		internal MetadataLoader MetadataLoader = new MetadataLoader();
		
		internal static ManualLogSource Logging { get; private set; } 
		public TNHMusicMod()
		{
			Logging = Logger;
			Logger.LogInfo("Loading TNHMusicMod");
			//Register the events, SceneLoaded and AssetLoaders
			//SceneManager.sceneLoaded += OnSceneLoad;
			Stages.Runtime += LoadAssets;
			
		}

		private void Awake()
		{
			foreach (var song in MetadataLoader.LoadedMetadata)
			{
				var data = song.Value;
				
				Logging.LogInfo($"Song Info from mod {song.Key.Info.Name}:\nName: {data.Name}\nLength: {data.Length}\nAuthors: {data.Authors}\nGenres: {data.Genres}");
			}
		}

		public void LoadAssets(RuntimeStage stage)
		{
			stage.ImmediateReaders.Add(YAMLReader<SongMetadata>.ReadFile);
			Logging.LogDebug("Added reader");
			stage.RuntimeAssetLoaders[Source, "songinfo"] = MetadataLoader.LoadAssets;
			Logging.LogDebug("Loaded assets");
			
			//stage.RuntimeAssetLoaders[Source, "song"] = AudioLoader.LoadAssets;
		}
	}
}