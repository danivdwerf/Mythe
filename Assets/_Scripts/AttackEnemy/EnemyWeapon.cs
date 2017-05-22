using UnityEngine;

/// <summary>
/// Enemy Weapon
/// </summary>
public class EnemyWeapon : MonoBehaviour 
{
    /// <summary>
    /// Reference to Animator component
    /// </summary>
	[SerializeField]private Animator anim;
    /// <summary>
    /// Reference to playerhealth script
    /// </summary>
	private PlayerHealth playerHealth;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    /// <summary>
    /// Raises the trigger enter event.
    /// </summary>
    /// <param name="other">Other.</param>
	private void OnTriggerEnter(Collider other)
	{
		if (!anim.GetBool ("attack"))
			return;

		playerHealth.takeDamage (10);
	}
}
