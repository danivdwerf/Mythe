using UnityEngine;
using UnityEngine.UI;

public class LoadUIHandler : MonoBehaviour 
{
    [SerializeField]private Text loadingText;
    [SerializeField]private GameObject[] panels;

    private LoadScene loadScene{get;set;}

    private void Start()
    {
        panels[0].SetActive(true);
        panels[1].SetActive(false);
        loadScene = this.GetComponent<LoadScene>();
    }

    public void startLoading()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(true);
    }

    public void updateUI()
    {
        var percentage = loadScene.Percentage;
        loadingText.text = "Loading: " + percentage + "%";
    }
}
