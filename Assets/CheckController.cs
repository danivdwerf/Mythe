using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour 
{
	private void Awake()
	{
		var joysticks = Input.GetJoystickNames()[0].ToLower();
		var os = System.Environment.OSVersion.Platform.ToString().ToLower();
		print (os);
		if (os.Contains("unix"))
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

		if (os.Contains("win"))
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

