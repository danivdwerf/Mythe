using UnityEngine;
using System.Collections;

public class Billboarding : MonoBehaviour {
	[SerializeField]private Camera mainCam;
	private GameObject target;
	//private Vector3 targetPosX;
	void Awake()
	{
		target = transform.parent.gameObject;
	}

	void Update () 
	{
		

		transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.forward,
			mainCam.transform.rotation * Vector3.up);

		transform.position = new Vector3 (target.transform.position.x, target.transform.localScale.y, target.transform.position.z);
	}
}
