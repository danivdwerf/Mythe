using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBone : MonoBehaviour 
{
	[SerializeField]private float spawnOffSetY;
	private Bones bones;
	private GameObject player;

	private void Start()
	{
		player = this.gameObject;
		bones = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Bones>();
	}

	private void Update()
	{
		if (Input.GetButtonDown (Controller.Cross))
			spawnBone ();
	}

	private void spawnBone()
	{
		var newBone = bones.getLastBone ();
		if (newBone == null)
			return;
		newBone.transform.position = player.transform.position - new Vector3(0, spawnOffSetY, 0);
		newBone.SetActive (true);
		bones.drawLines ();
	}
}
