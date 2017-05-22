using UnityEngine;

/// <summary>
/// Health.
/// </summary>
public abstract class Health : MonoBehaviour 
{
    /// <summary>
    /// The max health.
    /// </summary>
	[SerializeField]private float maxHealth;
    public float MaxHealth{get{return maxHealth;}}
    /// <summary>
    /// The current health.
    /// </summary>
	protected float curHealth;
	public float CurHealth{get{return curHealth;}}
    /// <summary>
    /// Boolean if person is dead.
    /// </summary>
	private bool dead;
	public bool Dead{get{return dead;} set{dead = value;}}

    /// <summary>
    /// Start this instance.
    /// </summary>
	protected virtual void Start()
	{
		curHealth = maxHealth;
		dead = false;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	protected virtual void Update()
	{
		if (curHealth <= 0 && !dead)
		{
			onDeath ();
			dead = true;
		}
	}

    /// <summary>
    /// Reset the healhth.
    /// </summary>
	public virtual void reset(){curHealth = maxHealth;}
    /// <summary>
    /// Takes the damage.
    /// </summary>
    /// <param name="damage">Damage.</param>
	public virtual void takeDamage(float damage){curHealth -= damage;}
	protected abstract void onDeath ();
}
