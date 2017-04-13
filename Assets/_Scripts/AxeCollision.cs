using UnityEngine;

public class AxeCollision : MonoBehaviour 
{
	[SerializeField]private ParticleSystem[] ps;
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), this.GetComponent<Collider>());
	}
	private void OnCollisionEnter(Collision other)
	{
		print (other.collider.name);
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
