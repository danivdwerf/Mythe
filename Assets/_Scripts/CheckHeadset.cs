using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class CheckHeadset : MonoBehaviour 
{
	private void Awake()
	{
		foreach (Process pro in Process.GetProcesses ())
		{
			try
			{
				if(pro.ProcessName.ToLower().Contains("steamvr"))
				{
					print("Go for the vive");
				}
			}
			catch{}
		}
	}
}
