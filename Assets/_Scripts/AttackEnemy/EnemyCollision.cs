using UnityEngine;

/// <summary>
/// Enemy collision.
/// </summary>
public class EnemyCollision : MonoBehaviour 
{
    /// <summary>
    /// Reference to the Enemyhealth.
    /// </summary>
	private EnemyHealth health;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		health = GetComponent<EnemyHealth> ();
	}

    /// <summary>
    /// Raises the collision enter event.
    /// </summary>
    /// <param name="other">Other.</param>
	private void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.tag != "Axe")
            return;

        if (other.rigidbody.velocity.sqrMagnitude >= 20)
            health.takeDamage(25);
	}
}
