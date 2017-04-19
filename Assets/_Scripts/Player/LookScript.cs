using UnityEngine;

public class LookScript : MonoBehaviour 
{
	private GameObject player;
	private float multiplier;
	private float maxRotate;

	private void Start()
	{
		player = this.transform.parent.gameObject;
		multiplier = 2f;
		maxRotate = 50;
	}

	private void Update()
	{
		var x = Input.GetAxisRaw (Controller.RightStickX);
		var y = Input.GetAxisRaw (Controller.RightStickY);
		this.transform.eulerAngles += new Vector3 (x, 0, 0).normalized * multiplier;
		var angle = this.transform.eulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		if (angle > maxRotate)
			this.transform.eulerAngles = new Vector3 (maxRotate, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		if (angle < -maxRotate)
			this.transform.eulerAngles = new Vector3 (-maxRotate, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		player.transform.localEulerAngles += new Vector3 (0, y, 0).normalized*multiplier;
	}
}
