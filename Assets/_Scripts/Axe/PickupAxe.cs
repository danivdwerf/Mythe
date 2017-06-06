using UnityEngine;
/// <summary>
/// Pickup axe.
/// </summary>
public class PickupAxe : MonoBehaviour 
{
    /// <summary>
    /// The axe.
    /// </summary>
	private Transform axe;
    /// <summary>
    /// The axe position.
    /// </summary>
	[SerializeField]private Transform axePos;
    /// <summary>
    /// The particlesystem.
    /// </summary>
	[SerializeField]private ParticleSystem ps;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
        axe = GameObject.FindGameObjectWithTag (Tags.axe).transform;
		if (axe == null)
			throw new System.Exception ("PickupAxe: Failed to find the axe");
	}

    /// <summary>
    /// Picks up the axe.
    /// </summary>
	public void pickupAxe()
	{
		axe.SetParent (axePos);
 
        axe.localPosition = new Vector3(0,0,0);
        axe.localEulerAngles = new Vector3(0, 0, 0);
		ps.Play ();
	}
}