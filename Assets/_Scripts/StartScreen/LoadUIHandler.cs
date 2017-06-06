using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Load user interface handler.
/// </summary>
public class LoadUIHandler : MonoBehaviour 
{
    /// <summary>
    /// The loading text.
    /// </summary>
    [SerializeField]private Text loadingText;
    [SerializeField]private Image loadbar;
    /// <summary>
    /// Reference to LoadScene;
    /// </summary>
    private LoadScene loadScene;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        loadScene = this.GetComponent<LoadScene>();
        loadbar.fillAmount = 0;
        loadingText.text = "Loading: 0%";
    }

    /// <summary>
    /// Updates the UI.
    /// </summary>
    public void updateUI(float percentage)
    {
        var edited = Mathf.Floor((percentage * 100) / 0.9f);
        loadbar.fillAmount = percentage / 0.9f;
        loadingText.text = "Loading: " + edited + "%";
    }
}
