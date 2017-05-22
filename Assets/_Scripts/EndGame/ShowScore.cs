using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField]TextMesh text;
    private void Start()
    {
        text.text = "";
        text.gameObject.SetActive(false);
    }

    public void showScore(float score)
    {
        text.text = "Final Score:\n"+score.ToString("N1");
        text.gameObject.SetActive(true);
    }
}
