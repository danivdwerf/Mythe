using UnityEngine;
using System.Collections;

/// <summary>
/// Throw input.
/// </summary>
public class ThrowInput : MonoBehaviour 
{
    /// <summary>
    /// Reference to ThrowAxe class.
    /// </summary>
	private ThrowAxe throwScript;
    /// <summary>
    /// Reference to PickupAxe class.
    /// </summary>
	private PickupAxe pickupAxe;

    private bool canPickup;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		throwScript = GetComponent<ThrowAxe> ();
		pickupAxe = GetComponent<PickupAxe> ();
        canPickup = false;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
        if (Input.GetButtonDown(Controller.R1))
        {
            throwScript.throwAxe();
            StartCoroutine("pickupTimer");
        }

        if (Input.GetButtonDown (Controller.Circle) && canPickup)
		{
			pickupAxe.pickupAxe ();
			throwScript.axeInHand ();
            canPickup = false;
		}
	}

    private IEnumerator pickupTimer()
    {
        canPickup = false;
        yield return new WaitForSeconds(5f);
        canPickup = true;
    }
}
