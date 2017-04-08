using UnityEngine;

public class ThrowAxe : MonoBehaviour 
{
	[SerializeField]private float throwPower;
	[SerializeField]private GameObject axe;
	private Rigidbody rigid;
	private bool inHand;

	private void Start()
	{
		inHand = true;
		rigid = axe.GetComponent<Rigidbody> ();
	}

	public void throwAxe()
	{
		if (!inHand)
			return;

		inHand = false;
		axe.transform.SetParent (null);
		rigid.useGravity = true;
		rigid.AddForce (axe.transform.forward * throwPower * Time.deltaTime, ForceMode.Impulse);
	}
}
