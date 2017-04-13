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
		rigid.useGravity = false;
		rigid.isKinematic = true;
	}

	public void throwAxe()
	{
		if (!inHand)
			return;

		inHand = false;
		axe.transform.SetParent (null);
		rigid.useGravity = true;
		rigid.isKinematic = false;
		rigid.AddForce (axe.transform.forward * throwPower * Time.deltaTime, ForceMode.Impulse);
	}
}
