using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBone : MonoBehaviour 
{
	[SerializeField]private float spawnOffSetY;
	private DrawLineToBones bones;
	private ObjectPooler bonePool;
	private GameObject player;
	private int amountOfBones;

	private void Start()
	{
		player = this.gameObject;
		bones = GameObject.FindGameObjectWithTag ("GameController").GetComponent<DrawLineToBones>();
		bonePool = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ObjectPooler>();
	}

	private void Update()
	{
		if (Input.GetButtonDown (Controller.Cross))
			spawnBone ();
	}

	public void addBone()
	{
		amountOfBones++;
	}

	private void spawnBone()
	{
		if (amountOfBones < 1)
			return;
		
		var newBone = bonePool.getObject ();
		if (newBone == null)
			return;
		
		amountOfBones--;
		newBone.transform.position = player.transform.position - new Vector3(0, spawnOffSetY, 0);
		newBone.SetActive (true);
		bones.drawLines ();
	}
}
