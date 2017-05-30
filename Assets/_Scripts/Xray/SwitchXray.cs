using UnityEngine;
using System.Collections;

/// <summary>
/// Switch xray.
/// </summary>
public class SwitchXray : MonoBehaviour 
{
    /// <summary>
    /// Boolean if the vision is activated.
    /// </summary>
	private bool _specVision;
    /// <summary>
    /// The objects that should be oulined.
    /// </summary>
	private OutlineObject[] objects;

    private AudioManager audioManager;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start () 
	{
		objects = FindObjectsOfType<OutlineObject> ();
        audioManager = this.GetComponent<AudioManager>();
		_specVision = false;
		normVision ();
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update () 
	{
		if (Input.GetButtonDown (Controller.L1))
			switchVision ();
	}

    /// <summary>
    /// Switchs the vision.
    /// </summary>
	public void switchVision()
	{
		if (_specVision)
			normVision ();
		else
			specVision ();
	}

    /// <summary>
    /// Norms the vision.
    /// </summary>
	private void normVision()
	{
        audioManager.playSound("XrayOff");
		_specVision = false;
        Camera.main.cullingMask &=  ~(1 << LayerMask.NameToLayer("DisText"));
		for (var i = 0; i < objects.Length; i++) 
		{
			objects [i].normalMat ();
		}
	}

    /// <summary>
    /// Specs the vision.
    /// </summary>
	private void specVision()
	{
        audioManager.playSound("XrayOn");
		_specVision = true;
        Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("DisText");
		for (var i = 0; i < objects.Length; i++) 
		{
			objects [i].visionMat ();
		}
	}
}
