using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour 
{

	[SerializeField]private Camera mainCamera;
	[SerializeField]private Camera visionCamera;
	private bool _specVision = false;
	private bool _normVision = false;

	[SerializeField]private Material[] materials;
	[SerializeField]private GameObject[] visionObjects;
	private int index;

	void Start () 
	{
		normVision ();
	}

	void Update () 
	{
		if (Input.GetKeyDown ("x")) 
		{
			_specVision = !_specVision;
			_normVision = !_normVision;
		} 

		if(_specVision == true)
		{
			specVision ();
		}
		else
		{
			normVision ();
		}
	}

	void normVision()
	{
		mainCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("DisText"));
	}

	void specVision()
	{
		mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("DisText");

	}
}