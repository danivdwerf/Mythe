using UnityEngine;
/// <summary>
/// Text size.
/// </summary>
public class TextSize : MonoBehaviour
{
    /// <summary>
    /// The distance.
    /// </summary>
	[SerializeField]private float distance;
    /// <summary>
    /// The dist.
    /// </summary>
	private float dist;
    /// <summary>
    /// The start scale.
    /// </summary>
	private Vector3 startScale;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start ()
	{
		startScale = transform.localScale;
		distance = 60;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update ()
	{
		scale();
	}

    /// <summary>
    /// Scale this instance.
    /// </summary>
	private void scale()
	{
		dist = Vector3.Distance(Camera.main.transform.position, transform.position);
		Vector3 newScale = startScale * (dist / distance);
		transform.localScale = newScale;
	}
}
