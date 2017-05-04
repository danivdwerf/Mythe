using UnityEngine;

public class PickupAxe : MonoBehaviour 
{
	private Transform axe;
	[SerializeField]private Transform axePos;
	[SerializeField]private ParticleSystem ps;

	private void Start()
	{
		axe = GameObject.FindGameObjectWithTag ("Axe").transform;
		if (axe == null)
			throw new System.Exception ("PickupAxe: Failed to find the axe");
	}

	public void pickupAxe()
	{
		axe.SetParent (axePos);
		axe.localPosition = Vector3.zero;
		axe.localEulerAngles = Vector3.zero;
		ps.Play ();
	}
}