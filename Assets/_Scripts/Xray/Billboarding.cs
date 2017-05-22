using UnityEngine;
using System.Collections;
/// <summary>
/// Billboarding.
/// </summary>
public class Billboarding : MonoBehaviour
{
    /// <summary>
    /// The main cam.
    /// </summary>
	[SerializeField]private Camera mainCam;
    /// <summary>
    /// The target.
    /// </summary>
	private GameObject target;

    /// <summary>
    /// Awake this instance.
    /// </summary>
	private void Awake()
	{
		target = transform.parent.gameObject;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update ()
	{


		transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.forward,
			mainCam.transform.rotation * Vector3.up);

		transform.position = new Vector3 (target.transform.position.x, target.transform.localScale.y, target.transform.position.z);
	}
}
