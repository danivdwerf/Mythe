using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroin : MonoBehaviour 
{
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller{ get{return SteamVR_Controller.Input((int)trackedObj.index);}}
	private GameObject collidingObject;
	private GameObject objectInHand;

	private void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	private void Update()
	{
		if (Controller.GetTouch (Valve.VR.EVRButtonId.k_EButton_DPad_Up))
		{
			this.transform.position += new Vector3(0,0,1);
		}

		if (Controller.GetTouch (Valve.VR.EVRButtonId.k_EButton_DPad_Right))
		{
			this.transform.position += new Vector3(1,0,0);
		}

		if (Controller.GetTouch (Valve.VR.EVRButtonId.k_EButton_DPad_Down))
		{
			this.transform.position += new Vector3(0,0,-1);
		}

		if (Controller.GetTouch (Valve.VR.EVRButtonId.k_EButton_DPad_Left))
		{
			this.transform.position += new Vector3(-1,0,0);
		}
	}
}
