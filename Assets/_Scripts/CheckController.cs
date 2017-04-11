﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour 
{
	private void Awake()
	{
		var joysticks = Input.GetJoystickNames()[0].ToLower();
		var os = System.Environment.OSVersion.Platform.ToString().ToLower();

		if (os.Contains("unix") || os.Contains("mac"))
		{
			if (joysticks.Contains ("sony"))
			{
				Controller.setController (ControllerType.playstation, Os.mac);
				return;
			}

			if (joysticks.Contains ("xbox"))
			{
				Controller.setController (ControllerType.xbox, Os.mac);
				return;
			}
		}

		if (os.Contains("win") || os.Contains("win32int")) 
		{
			if (joysticks.Contains ("sony"))
			{
				Controller.setController (ControllerType.playstation, Os.windows);
				return;
			}

			if (joysticks.Contains ("xbox"))
			{
				Controller.setController (ControllerType.xbox, Os.windows);
				return;
			}
		}
	}
}