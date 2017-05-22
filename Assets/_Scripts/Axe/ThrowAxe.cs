using UnityEngine;
/// <summary>
/// Throw axe.
/// </summary>
public class ThrowAxe : MonoBehaviour 
{
    /// <summary>
    /// The throw power.
    /// </summary>
	[SerializeField]private float throwPower;
    /// <summary>
    /// The axe.
    /// </summary>
	[SerializeField]private GameObject axe;
    /// <summary>
    /// Reference to the Rigidbody.
    /// </summary>
	private Rigidbody rigid;
    /// <summary>
    /// Boolean if axe is in hand.
    /// </summary>
	private bool inHand;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		inHand = true;
		rigid = axe.GetComponent<Rigidbody> ();
		rigid.useGravity = false;
		rigid.isKinematic = true;
	}

    /// <summary>
    /// Throws the axe.
    /// </summary>
	public void throwAxe()
	{
		if (!inHand)
			return;

		inHand = false;
		axe.transform.SetParent (null);
		rigid.useGravity = true;
		rigid.isKinematic = false;
		var dir = Camera.main.transform.forward + new Vector3 (0, 0.3f, 0);
		rigid.AddForce (dir  * throwPower, ForceMode.Impulse);
	}

    /// <summary>
    /// Resets the axe to be in the hand.
    /// </summary>
	public void axeInHand()
	{
		inHand = true;
		rigid.useGravity = false;
		rigid.isKinematic = true;
		rigid.velocity = Vector3.zero;
	}
}
