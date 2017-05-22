using UnityEngine;

/// <summary>
/// Look script.
/// </summary>
public class LookScript : MonoBehaviour 
{
    /// <summary>
    /// The player.
    /// </summary>
	private GameObject player;
    /// <summary>
    /// The look speed.
    /// </summary>
	[SerializeField]private float lookSpeed;
    /// <summary>
    /// The max rotation.
    /// </summary>
	[SerializeField]private float maxRotate;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		player = this.transform.parent.gameObject;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		var x = Input.GetAxisRaw (Controller.RightStickX);
		var y = Input.GetAxisRaw (Controller.RightStickY);
		this.transform.eulerAngles += new Vector3 (x, 0, 0).normalized * lookSpeed * Time.deltaTime;
		var angle = this.transform.eulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		if (angle > maxRotate)
			this.transform.eulerAngles = new Vector3 (maxRotate, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		if (angle < -maxRotate)
			this.transform.eulerAngles = new Vector3 (-maxRotate, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		player.transform.localEulerAngles += new Vector3 (0, y, 0).normalized*lookSpeed*Time.deltaTime;
	}
}
