using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	[SerializeField]private Audio[] audioFiles;

	private void Awake()
	{
		for (var i = 0; i < audioFiles.Length; i++)
		{
			GameObject go = new GameObject ("Audio: " + audioFiles[i].Name.ToString());
			go.transform.SetParent (this.transform);
			audioFiles [i].setSource (go.AddComponent<AudioSource>());
		}
	}

	public void playSound(string name)
	{
		audioLoop (name).play ();
	}

	public void stopSound(string name)
	{
		audioLoop (name).stop ();	
	}

	private Audio audioLoop(string name)
	{
		for (var i = 0; i < audioFiles.Length; i++)
		{
			if (audioFiles [i].Name == name)
			{
				return audioFiles[i];
			}
		}
		throw new System.Exception ("AudioManager: Could not find: " + name);
	}
}
