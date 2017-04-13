using UnityEngine;

public class ThrowInput : MonoBehaviour 
{
	private ThrowAxe throwScript;

	private void Start()
	{
		throwScript = GetComponent<ThrowAxe> ();
	}

	private void Update()
	{
		if (Input.GetButtonDown (Controller.R1))
			throwScript.throwAxe ();
	}
}
