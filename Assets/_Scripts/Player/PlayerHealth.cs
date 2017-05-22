using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player health.
/// </summary>
public class PlayerHealth : Health 
{
    private EndRoom endRoom;
    /// <summary>
    /// Reference to HealthUI.
    /// </summary>
    private HealthUI ui;
    /// <summary>
    /// Start this instance.
    /// </summary>

    public delegate void TakeDamageEvent();
    public TakeDamageEvent onDamage;
	protected override void Start ()
	{
		base.Start ();
        ui = this.GetComponent<HealthUI>();
        endRoom = GameObject.FindGameObjectWithTag("GameController").GetComponent<EndRoom>();
	}

    public void addHealth(float amount)
    {
        curHealth += amount;
        ui.updateUI();
    }

    /// <summary>
    /// Takes the damage.
    /// </summary>
    /// <param name="damage">Damage.</param>
    public override void takeDamage(float damage)
    {
        base.takeDamage(damage);
        if (onDamage != null)
            onDamage();
        ui.updateUI();
    }

    /// <summary>
    /// Called when person dies.
    /// </summary>
	protected override void onDeath ()
	{
        endRoom.onEnd();
        ui.disableUI();
	}
}
