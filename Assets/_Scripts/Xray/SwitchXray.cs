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

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start () 
	{
		objects = FindObjectsOfType<OutlineObject> ();
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
		_specVision = true;
        Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("DisText");
		for (var i = 0; i < objects.Length; i++) 
		{
			objects [i].visionMat ();
		}
	}
}
