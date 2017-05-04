using System.Collections;
using UnityEngine;

public class EnemyHealth : Person
{
	private Animator anim;
	[SerializeField]private AnimationClip death;
	protected override void Start ()
	{
		base.Start ();
		anim = this.GetComponent<Animator> ();
	}

	protected override void onDeath ()
	{
		StartCoroutine ("die");
	}

	private IEnumerator die()
	{
		anim.SetBool ("dead", true);
		yield return new WaitForSeconds (death.length+4);
		this.gameObject.SetActive (false);
	}
}