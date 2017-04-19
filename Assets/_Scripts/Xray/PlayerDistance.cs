using UnityEngine;
using System.Collections;

public class PlayerDistance : MonoBehaviour {

	private float distance;
	[SerializeField]private Transform target;
	[SerializeField]private TextMesh disText;
	private float timer;
	private float timerValue;

	void Start()
	{
		timerValue = 3;
		checkDistance ();
		returnTimer();
	}

	void FixedUpdate()
	{
		timer -= Time.fixedDeltaTime;
		if (timer < 0) {
			checkDistance ();
			returnTimer();
		}
	}
		
	void checkDistance()
	{
		
		distance = Vector3.Distance (transform.position, target.position) / 2;
		Mathf.Round(distance);
		if (distance < 60) {
			disText.text = distance.ToString ("#.00") + "m";
		} else {
			disText.text = " ";
		}
	}

	void returnTimer()
	{
		timer = timerValue;
	}
}
