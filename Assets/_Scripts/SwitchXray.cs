using UnityEngine;
using System.Collections;

public class SwitchXray : MonoBehaviour {

	private OutlineObject[] objects;

	// Use this for initialization
	void Start () {
		objects = FindObjectsOfType<OutlineObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x")) 
		{
			for (var i = 0; i < objects.Length; i++) {
				objects [i].switchMat ();
			}

		}
	}
}
