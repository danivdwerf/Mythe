using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health UI.
/// </summary>
public class HealthUI : MonoBehaviour 
{
    /// <summary>
    /// The health indicator.
    /// </summary>
    [SerializeField]private Image healthIndicator;
    /// <summary>
    /// Reference to PlayerHealth class.
    /// </summary>
    private PlayerHealth health;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        health = this.GetComponent<PlayerHealth>();
        updateUI();
    }

    /// <summary>
    /// Updates the UI.
    /// </summary>
    public void updateUI()
    {
        var alpha = 1 - (health.CurHealth / health.MaxHealth);
        healthIndicator.color = new Color(healthIndicator.color.r, healthIndicator.color.g, healthIndicator.color.b, alpha);
    }

    public void disableUI()
    {
        healthIndicator.gameObject.SetActive(false);
    }
}
