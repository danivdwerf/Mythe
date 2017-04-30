using UnityEngine;

public abstract class Person : MonoBehaviour 
{
	[SerializeField]private float maxHealth;
	[SerializeField]protected float curHealth;
	public float Health{get{return curHealth;}}
	private bool dead;
	public bool Dead{get{return dead;} set{dead = value;}}

	protected virtual void Start()
	{
		curHealth = maxHealth;
		dead = false;
	}

	protected virtual void Update()
	{
		if (curHealth <= 0 && !dead)
		{
			onDeath ();
			dead = true;
		}
	}

	public virtual void reset(){curHealth = maxHealth;;}
	public virtual void takeDamage(float damage){curHealth -= damage;}
	protected abstract void onDeath ();
}
