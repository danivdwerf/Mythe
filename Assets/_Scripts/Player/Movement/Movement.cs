using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
/// <summary>
/// Movement.
/// </summary>
public class Movement : MonoBehaviour 
{
    /// <summary>
    /// The speed.
    /// </summary>
	[Range(1, 5)][SerializeField]private float speed;
    /// <summary>
    /// The left arm animator.
    /// </summary>
	[SerializeField]private Animator leftArm;
    /// <summary>
    /// The right arm animator.
    /// </summary>
	[SerializeField]private Animator rightArm;
    /// <summary>
    /// Reference to the Rigidbody.
    /// </summary>
	private Rigidbody rigid;
    /// <summary>
    /// The movement.
    /// </summary>
	private Vector3 movement;
    /// <summary>
    /// Reference to AudioManager class.
    /// </summary>
	private AudioManager audioManager;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		rigid = GetComponent<Rigidbody> ();
		audioManager = FindObjectOfType<AudioManager> ();
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		var x = Input.GetAxis (Controller.LeftStickX);
		var z = Input.GetAxis (Controller.LeftStickY);
		movement = new Vector3 (x,0,z);
	}

    /// <summary>
    /// Updates according the framerate.
    /// </summary>
	private void FixedUpdate()
	{
		Vector3 velocity = transform.TransformDirection(movement.normalized) *  speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.transform.localPosition + velocity);
        var mag = Mathf.Abs(velocity.z*10);
		leftArm.SetFloat ("velocity", mag);
		rightArm.SetFloat ("velocity", mag);
		if (mag >= 0.05f)
			audioManager.playSound ("step");
	}
}
