﻿using UnityEngine;

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
		var dir = Camera.main.transform.forward + new Vector3 (0, 0.3f, 0);
		rigid.AddForce (dir  * throwPower * Time.deltaTime, ForceMode.Impulse);
	}

	public void axeInHand()
	{
		inHand = true;
		rigid.useGravity = false;
		rigid.isKinematic = true;
		rigid.velocity = Vector3.zero;
	}
}
