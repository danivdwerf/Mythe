using System.Collections;
using UnityEngine;

/// <summary>
/// Enemy health.
/// </summary>
public class EnemyHealth : Health
{
    /// <summary>
    /// Reference to the animator component.
    /// </summary>
	private Animator anim;
    /// <summary>
    /// Reference to the death clip.
    /// </summary>
	[SerializeField]private AnimationClip death;

    /// <summary>
    /// Start this instance.
    /// </summary>
	protected override void Start ()
	{
		base.Start ();
		anim = this.GetComponent<Animator> ();
	}

    /// <summary>
    /// Called when enemy dies.
    /// </summary>
	protected override void onDeath ()
	{
		StartCoroutine ("die");
	}

    /// <summary>
    /// Logic of the enemy dying.
    /// </summary>
	private IEnumerator die()
	{
		anim.SetBool ("dead", true);
		yield return new WaitForSeconds (death.length+4);
		this.gameObject.SetActive (false);
        this.gameObject.SetActive (true);
	}
}