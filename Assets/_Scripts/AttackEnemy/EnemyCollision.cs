using UnityEngine;

public class EnemyCollision : MonoBehaviour 
{
	private EnemyHealth health;

	private void Start()
	{
		health = GetComponent<EnemyHealth> ();
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "Axe")
			return;

		health.takeDamage (25);
	}
}
