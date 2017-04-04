using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour 
{
	private void Awake()
	{
		var joysticks = Input.GetJoystickNames();
		for (int i = 0; i < joysticks.Length; i++)
		{
			if (joysticks [i].ToLower ().Contains ("sony"))
				setPlaystation ();

			if (joysticks [i].ToLower ().Contains ("xbox"))
				setXbox ();
		}
	}

	private void Update()
	{
		//if(Input.GetAxis("dpadUp"))
		print(Input.GetAxis("dpadUp"));
		//print (Input.GetAxis(Controller.leftStickX));
	}

	private void setPlaystation()
	{
		
	}

	private void setXbox()
	{
		
	}
}
