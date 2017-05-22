using UnityEngine;

[System.Serializable]
/// <summary>
/// Audio.
/// </summary>
public class Audio
{
    /// <summary>
    /// The name of the clip.
    /// </summary>
	[SerializeField]private string name;
	public string Name{get{return name;}}
    /// <summary>
    /// The Audioclip
    /// </summary>
	[SerializeField]private AudioClip clip;
    /// <summary>
    /// The volume.
    /// </summary>
	[Range(0,1)][SerializeField]private float volume;
    /// <summary>
    /// The pitch.
    /// </summary>
	[Range(-3, 3)][SerializeField]private float pitch;
    /// <summary>
    /// The panning.
    /// </summary>
	[Range(-1, 1)][SerializeField]private float panning;
    /// <summary>
    /// Boolean if the clip should loop.
    /// </summary>
	[SerializeField]private bool loop;
    /// <summary>
    /// The Audiosource.
    /// </summary>
	private AudioSource source;

    /// <summary>
    /// Sets the source.
    /// </summary>
    /// <param name="source">Source.</param>
	public void setSource(AudioSource source)
	{
		this.source = source;
		this.source.playOnAwake = false;
		this.source.clip = this.clip;
		this.source.volume = this.volume;
		this.source.pitch = this.pitch;
		this.source.panStereo = this.panning;
		this.source.loop = this.loop;
	}

    /// <summary>
    /// Play this clip.
    /// </summary>
	public void play()
	{
		if(!this.source.isPlaying)
			this.source.Play ();
	}

    /// <summary>
    /// Stop this clip.
    /// </summary>
	public void stop()
	{
		this.source.Stop ();
	}
}
