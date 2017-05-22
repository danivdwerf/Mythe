using UnityEngine;
using System.Collections;

/// <summary>
/// Attackenemy Logic
/// </summary>
public class AttackingEnemy : MonoBehaviour 
{
    /// <summary>
    /// Reference to the targer.
    /// </summary>
	[SerializeField]private GameObject target;
    /// <summary>
    /// The walking speed multiplier.
    /// </summary>
	[SerializeField]private float speedMultiplier;
    /// <summary>
    /// Reference to the Animator.
    /// </summary>
	private Animator anim;
    /// <summary>
    /// Reference to the health script.
    /// </summary>
	private EnemyHealth health;
    /// <summary>
    /// Reference to ObjectPooler class.
    /// </summary>
    private ObjectPooler pooler;
    /// <summary>
    /// Boolean if the enemy is already attacking.
    /// </summary>
	private bool attacking;

    static readonly int _hasTarget = Animator.StringToHash("hasTarget");
    static readonly int _dead = Animator.StringToHash("dead");
    static readonly int _attack = Animator.StringToHash("attack");
    static readonly int _follow = Animator.StringToHash("follow");

    /// <summary>
    /// Awake this instance.
    /// </summary>
	private void Awake()
	{
		anim = this.GetComponent<Animator> ();
		health = this.GetComponent<EnemyHealth> ();
        pooler = GameObject.FindGameObjectWithTag("GameController").GetComponent<ObjectPooler>();
	}

    /// <summary>
    /// Raises the enable event.
    /// </summary>
	private void OnEnable()
    {
        anim.SetBool (_hasTarget, true);
        anim.SetBool (_dead, false);
        anim.SetBool (_attack, false);
        anim.SetBool (_follow, false);
		health.Dead = false;
		attacking = false;

		if (target == null)
            anim.SetBool (_hasTarget, false);
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		var dir = (this.transform.position - target.transform.position);
		if (Mathf.Abs(dir.sqrMagnitude) <= 15f)
			attack ();
        else if(!attacking && !anim.GetBool(_dead))
			follow (dir);
	}

    /// <summary>
    /// Follow the specified dir.
    /// </summary>
    /// <param name="dir">Dir.</param>
	private void follow(Vector3 dir)
	{
        anim.SetBool (_follow, true);
        anim.SetBool (_attack, false);
		var lookPosition = target.transform.position - this.transform.position;
		lookPosition.y = 0;
		var rotation = Quaternion.LookRotation (lookPosition);
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, rotation, Time.deltaTime * 6);
		this.transform.position -= dir.normalized * speedMultiplier * Time.deltaTime;
	}

    /// <summary>
    /// Attack Logic.
    /// </summary>
	private void attack()
	{
        anim.SetBool (_follow, false);
        anim.SetBool (_attack, true);
		attacking = true;
	}

    /// <summary>
    /// Called when the attack animation is finnished.
    /// </summary>
	public void finishAttack()
	{
		attacking = false;
	}

    /// <summary>
    /// Raises the disable event.
    /// </summary>
	private void OnDisable()
	{
        var bone = pooler.getObject();
        bone.transform.position = this.transform.position;
        bone.SetActive(true);

		this.transform.position = new Vector3 (95, 10, 56);
		health.reset ();
	}
}
