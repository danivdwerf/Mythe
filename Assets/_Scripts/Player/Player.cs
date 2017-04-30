using UnityEngine;

public class Player : Person 
{
	private Movement movementScript;
	private LookScript lookScript;
	protected override void Start ()
	{
		base.Start ();
		movementScript = this.GetComponent<Movement> ();
		lookScript = FindObjectOfType<LookScript> ();
	}

	protected override void onDeath ()
	{
		print ("dead");
		lookScript.enabled = false;
		movementScript.enabled = false;
		this.enabled = false;
	}
}
