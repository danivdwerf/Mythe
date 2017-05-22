using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class EndRoom : MonoBehaviour
{
    private ScoreTimer scoreTimer;
    private ShowScore visualScore;
    [SerializeField]private Transform player;
    [SerializeField]private Image darkView;
    [SerializeField]private GameObject level;

    private Vector3 position;
    private Vector3 rotation;
    private void Start()
    {
        scoreTimer = this.GetComponent<ScoreTimer>();
        visualScore = this.GetComponent<ShowScore>();

        position = new Vector3(-3f, 1f, -21.5f);
        rotation = new Vector3(0, 90, 0);
        darkView.color = new Color (0, 0, 0, 0);
        darkView.sprite = null;
    }

    public void onEnd()
    {
        StartCoroutine("fade");
        visualScore.showScore(scoreTimer.endTimer());
    }

    private IEnumerator fade()
    {
        while (darkView.color.a < 1) 
        {
            var alpha = darkView.color.a + 0.1f;
            darkView.color = new Color (0, 0, 0, alpha);
            Canvas.ForceUpdateCanvases();
            yield return new WaitForSeconds (0.01f);
        }

        player.transform.position = this.position;
        player.eulerAngles = this.rotation;
        level.SetActive(false);

        while (darkView.color.a > 0) 
        {
            var alpha = darkView.color.a - 0.1f;
            darkView.color = new Color (0, 0, 0, alpha);
            Canvas.ForceUpdateCanvases();
            yield return new WaitForSeconds (0.01f);
        }
    }
}
