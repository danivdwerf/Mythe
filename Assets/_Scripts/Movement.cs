using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour 
{
	[Range(5,20)]
	[SerializeField]private float speed;
	[SerializeField]private Animator leftArm;
	[SerializeField]private Animator rightArm;
	private Rigidbody rigid;
	private Vector3 movement;
	private AudioManager audio;

	private void Start()
	{
		rigid = GetComponent<Rigidbody> ();
		audio = FindObjectOfType<AudioManager> ();
	}

	private void Update()
	{
		var x = Input.GetAxis (Controller.LeftStickX);
		var z = Input.GetAxis (Controller.LeftStickY);
		movement = new Vector3 (x,0,z);
	}

	private void FixedUpdate()
	{
		Vector3 velocity = transform.TransformDirection(movement.normalized) * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + velocity);
		var mag = velocity.sqrMagnitude;
		leftArm.SetFloat ("velocity", mag);
		rightArm.SetFloat ("velocity", mag);
		print (mag);
		if (mag >= 0.01)
			audio.playSound ("step");
	}
}
