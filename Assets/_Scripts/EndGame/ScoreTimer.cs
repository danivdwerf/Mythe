using UnityEngine;

public class ScoreTimer : MonoBehaviour 
{
    private float startTime, endTime;
    private void Start()
    {
        startTime = Time.time; 
    }

    public float endTimer()
    {
        endTime = Time.time;
        return (endTime-startTime);
    }
}
