using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LoadUIHandler))]
public class LoadScene : MonoBehaviour 
{
    private float percentage{get;set;}
    public float Percentage{get;}
    private LoadUIHandler uiHandler{get;set;}

    private void Start()
    {
        percentage = 0;
        uiHandler = this.GetComponent<LoadUIHandler>();
    }

    public void loadScene(int sceneIndex)
    {
        StartCoroutine(load(sceneIndex));
    }

    private IEnumerator load(int sceneIndex)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);
        uiHandler.startLoading();

        while (!loading.isDone)
        {
            percentage = Mathf.Floor((loading.progress * 100) / 0.9f);
            uiHandler.updateUI();
            yield return null;
        }
    }
}
