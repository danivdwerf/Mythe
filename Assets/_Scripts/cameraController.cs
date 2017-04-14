using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class cameraController : MonoBehaviour {

	[SerializeField]private Camera mainCamera;
	[SerializeField]private Camera visionCamera;
	private bool _specVision = false;
	private bool _normVision = false;
	private Grayscale grayScale; 

	[SerializeField]private Material[] materials;
	[SerializeField]private GameObject[] visionObjects;
	private int index;

	void Start () 
	{
		visionObjects = GameObject.FindGameObjectsWithTag ("vObj");

		normVision ();
		//grayScale = Camera.main.GetComponent<Grayscale> ();
	}

	void Update () 
	{
		if (Input.GetKeyDown ("x")) {
			//grayScale.enabled = !grayScale.enabled;
			_specVision = !_specVision;
			_normVision = !_normVision;
		} 

		if(_specVision == true){
			specVision ();
		}else{
			normVision ();
		}
	}

	void FixedUpdate()
	{
		visionObjects = GameObject.FindGameObjectsWithTag ("vObj");

	}

	void normVision()
	{


		mainCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("DisText"));
		//mainCamera.gameObject.SetActive(true);
		//visionCamera.gameObject.SetActive (false);
	}

	void specVision()
	{
		mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("DisText");
		//mainCamera.gameObject.SetActive(true);
		//visionCamera.gameObject.SetActive (true);

	}




}