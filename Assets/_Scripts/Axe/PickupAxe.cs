using UnityEngine;

public class PickupAxe : MonoBehaviour 
{
	private Transform axe;
	[SerializeField]private Transform axePos;

	private void Start()
	{
		axe = GameObject.FindGameObjectWithTag ("Axe").transform;
		if (axe == null)
			throw new System.Exception ("PickupAxe: Failed to find the axe");
	}

	public void pickupAxe()
	{
		axe.SetParent (axePos);
		axe.localPosition = axePos.localPosition;
		axe.localEulerAngles = new Vector3 (0,0,0);
	}
}