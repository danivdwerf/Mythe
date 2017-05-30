using UnityEngine;
/// <summary>
/// Axe collision.
/// </summary>
public class AxeCollision : MonoBehaviour 
{
    /// <summary>
    /// The particlesystems.
    /// </summary>
	[SerializeField]private ParticleSystem[] ps;
    private AudioManager audioManager;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Collider>(), this.GetComponent<Collider>());
        audioManager = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<AudioManager>();
	}

    /// <summary>
    /// Raises the collision enter event.
    /// </summary>
    /// <param name="other">Other.</param>
	private void OnCollisionEnter(Collision other)
	{
        
		var index = 0;
        if (ps [index].isPlaying)
			index = 1;

        if (ps [index].isPlaying)
			index = 0;

		ps[index].transform.position = this.transform.position;
		ps[index].transform.LookAt (Camera.main.transform);
		ps[index].Play ();
        audioManager.playSound("AxeHitTree");
	}
}
