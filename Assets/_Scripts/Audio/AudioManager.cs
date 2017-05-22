using UnityEngine;

/// <summary>
/// Audio manager.
/// </summary>
public class AudioManager : MonoBehaviour 
{
    /// <summary>
    /// The audio files.
    /// </summary>
	[SerializeField]private Audio[] audioFiles;

    /// <summary>
    /// Awake this instance.
    /// </summary>
	private void Awake()
	{
		for (var i = 0; i < audioFiles.Length; i++)
		{
			GameObject go = new GameObject ("Audio: " + audioFiles[i].Name.ToString());
			go.transform.SetParent (this.transform);
			audioFiles [i].setSource (go.AddComponent<AudioSource>());
		}
	}

    /// <summary>
    /// Plays the sound by name.
    /// </summary>
    /// <param name="name">Name.</param>
	public void playSound(string name)
	{
		audioLoop (name).play ();
	}

    /// <summary>
    /// Stops the sound by name.
    /// </summary>
    /// <param name="name">Name.</param>
	public void stopSound(string name)
	{
		audioLoop (name).stop ();	
	}

    /// <summary>
    /// Loops through audio files and return the file with the given name.
    /// </summary>
    /// <returns>The loop.</returns>
    /// <param name="name">Name.</param>
	private Audio audioLoop(string name)
	{
		for (var i = 0; i < audioFiles.Length; i++)
		{
			if (audioFiles [i].Name == name)
			{
				return audioFiles[i];
			}
		}
        return null;
	}
}
