using UnityEngine;

public class EnemyWeapon : MonoBehaviour 
{
	[SerializeField]private Animator anim;
	[SerializeField]private Player playerHealth;

	private void OnTriggerEnter(Collider other)
	{
		if (!anim.GetBool ("attack"))
			return;

		playerHealth.takeDamage (10);
	}
}
