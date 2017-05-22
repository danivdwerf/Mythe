using UnityEngine;
using System.Collections;

/// <summary>
/// Player distance.
/// </summary>
public class PlayerDistance : MonoBehaviour
{
    /// <summary>
    /// The distance.
    /// </summary>
	private float distance;
    /// <summary>
    /// The target.
    /// </summary>
	[SerializeField]private Transform target;
    /// <summary>
    /// The dis text.
    /// </summary>
	[SerializeField]private TextMesh disText;
    /// <summary>
    /// The timer.
    /// </summary>
	private float timer;
    /// <summary>
    /// The timer value.
    /// </summary>
	private float timerValue;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		timerValue = 3;
		checkDistance ();
		returnTimer();
	}

    /// <summary>
    /// Updates according to the framerate.
    /// </summary>
	private void FixedUpdate()
	{
		timer -= Time.fixedDeltaTime;
		if (timer < 0)
        {
			checkDistance ();
			returnTimer();
		}
	}

    /// <summary>
    /// Checks the distance.
    /// </summary>
	private void checkDistance()
	{

		distance = Vector3.Distance (transform.position, target.position) / 2;
		Mathf.Round(distance);
		if (distance < 60)
        {
			disText.text = distance.ToString ("#.00") + "m";
		}
        else
        {
			disText.text = " ";
		}
	}

    /// <summary>
    /// Resets the timer.
    /// </summary>
	private void returnTimer()
	{
		timer = timerValue;
	}
}
