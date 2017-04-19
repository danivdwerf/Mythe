using UnityEngine;

public class TextSize : MonoBehaviour {
	[SerializeField]private float distance;
	private float dist;
	Vector3 startScale;

	void Start () 
	{
		startScale = transform.localScale;
		distance = 60;
	}

	void Update () 
	{
		scale();

	}

	void scale()
	{
		dist = Vector3.Distance(Camera.main.transform.position, transform.position); 
		Vector3 newScale = startScale * (dist / distance);
		transform.localScale = newScale;
	} 
}
