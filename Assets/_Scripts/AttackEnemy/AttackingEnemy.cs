using UnityEngine;
using System.Collections;

public class AttackingEnemy : MonoBehaviour 
{
	[SerializeField]private GameObject target;
	[SerializeField]private float speedMultiplier;
	private Animator anim;
	private EnemyHealth health;
    private ObjectPooler pooler;
	private bool attacking;

	private void Awake()
	{
		anim = this.GetComponent<Animator> ();
		health = this.GetComponent<EnemyHealth> ();
        pooler = GameObject.FindGameObjectWithTag("GameController").GetComponent<ObjectPooler>();
	}

	private void OnEnable()
    {
		anim.SetBool ("hasTarget", true);
		anim.SetBool ("dead", false);
		anim.SetBool ("attack", false);
		anim.SetBool ("follow", false);
		health.Dead = false;
		attacking = false;

		if (target == null)
			anim.SetBool ("hasTarget", false);
	}

	private void Update()
	{
		var dir = (this.transform.position - target.transform.position);
		if (Mathf.Abs(dir.sqrMagnitude) <= 15f)
			attack ();
		else if(!attacking && !anim.GetBool("dead"))
			follow (dir);
	}

	private void follow(Vector3 dir)
	{
		anim.SetBool ("follow", true);
		anim.SetBool ("attack", false);
		var lookPosition = target.transform.position - this.transform.position;
		lookPosition.y = 0;
		var rotation = Quaternion.LookRotation (lookPosition);
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, rotation, Time.deltaTime * 6);
		this.transform.position -= dir.normalized * speedMultiplier * Time.deltaTime;
	}

	private void attack()
	{
		anim.SetBool ("follow", false);
		anim.SetBool ("attack", true);
		attacking = true;
	}

	public void finishAttack()
	{
		attacking = false;
	}

	private void OnDisable()
	{
        var bone = pooler.getObject();
        bone.transform.position = this.transform.position;
        bone.SetActive(true);

		this.transform.position = new Vector3 (95, 10, 56);
		health.reset ();
	}
}
