using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private float speed;
	private float rotateL;
	private float rotateR;
	private float timer;

	void Start () 
	{
		move ();
	}

	void Update () 
	{
		timer -= Time.fixedDeltaTime;
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		transform.Rotate (Vector3.up * Time.deltaTime * rotateL);
		transform.Rotate (Vector3.down * Time.deltaTime * rotateR);

		if (timer < 0) {
			move ();
		}
	}

	void move()
	{
		rotateL = Random.Range (0f, 200f);
		rotateR = Random.Range (0f, 200f);
		speed = Random.Range (0.0f, 6.0f);
		timer = Random.Range (0.5f, 2f);
	}



}