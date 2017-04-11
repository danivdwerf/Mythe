using UnityEngine;

public class AxeCollision : MonoBehaviour 
{
	[SerializeField]private ParticleSystem[] ps;
	private void OnCollisionEnter(Collision other)
	{
		var index = 0;
		if (ps [index].isPlaying)
		{
			index = 1;
		}

		ps[index].transform.position = this.transform.position;
		ps[index].transform.LookAt (Camera.main.transform);
		ps[index].Play ();
	}
}
