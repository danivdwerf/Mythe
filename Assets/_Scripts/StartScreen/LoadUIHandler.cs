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
    /// <summary>
    /// The panels.
    /// </summary>
    [SerializeField]private GameObject[] panels;
    /// <summary>
    /// Reference to LoadScene;
    /// </summary>
    private LoadScene loadScene;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        panels[0].SetActive(true);
        panels[1].SetActive(false);
        loadScene = this.GetComponent<LoadScene>();
    }

    /// <summary>
    /// Starts with loading.
    /// </summary>
    public void startLoading()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(true);
    }

    /// <summary>
    /// Updates the UI.
    /// </summary>
    public void updateUI()
    {
        var percentage = loadScene.Percentage;
        loadingText.text = "Loading: " + percentage + "%";
    }
}
