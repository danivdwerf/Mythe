using UnityEngine;

public class ThrowInput : MonoBehaviour 
{
	private ThrowAxe throwScript;
	private PickupAxe pickupAxe;

	private void Start()
	{
		throwScript = GetComponent<ThrowAxe> ();
		pickupAxe = GetComponent<PickupAxe> ();
	}

	private void Update()
	{
		if (Input.GetButtonDown (Controller.R1))
			throwScript.throwAxe ();

		if (Input.GetButtonDown (Controller.Circle))
		{
			pickupAxe.pickupAxe ();
			throwScript.axeInHand ();
		}
	}
}
