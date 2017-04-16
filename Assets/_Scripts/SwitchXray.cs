using UnityEngine;
using System.Collections;

public class SwitchXray : MonoBehaviour 
{
	[SerializeField]private Camera mainCamera;
	private bool _specVision;
	private OutlineObject[] objects;

	private void Start () 
	{
		objects = FindObjectsOfType<OutlineObject> ();
		_specVision = false;
		normVision ();
	}

	private void Update () 
	{
		if (Input.GetButtonDown (Controller.L1))
		{
			switchVision ();
		}
	}

	public void switchVision()
	{
		if (_specVision)
		{
			normVision ();
		} 
		else
		{
			specVision ();
		}
	}

	private void normVision()
	{
		mainCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("DisText"));
		_specVision = false;
	}

	private void specVision()
	{
		mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("DisText");
		for (var i = 0; i < objects.Length; i++) 
		{
			objects [i].switchMat ();
		}
		_specVision = true;
	}
}
