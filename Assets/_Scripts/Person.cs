using UnityEngine;

public abstract class Person : MonoBehaviour 
{
	[SerializeField]private float maxHealth;
	protected float curHealth;
	public float Health{get{return curHealth;}}

	protected virtual void Start()
	{
		curHealth = maxHealth;
	}

	protected virtual void Update()
	{
		if (Input.GetButtonDown (Controller.Triangle))
			takeDamage (15);
		
		if (curHealth <= 0)
			onDeath ();
	}

	protected abstract void takeDamage(float damage);
	protected abstract void onDeath ();
}
