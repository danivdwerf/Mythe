using UnityEngine;
/// <summary>
/// Bone pickup.
/// </summary>
public class BonePickup : MonoBehaviour 
{
    /// <summary>
    /// Reference to the players transform.
    /// </summary>
	private Transform player;
    /// <summary>
    /// Reference to the SpawnBone class.
    /// </summary>
	private SpawnBone bone;
    /// <summary>
    /// Reference to the DrawLineToBones class.
    /// </summary>
    private DrawLineToBones draw;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		bone = FindObjectOfType<SpawnBone>();
        draw = FindObjectOfType<DrawLineToBones>();
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		if (Input.GetButtonDown (Controller.Square)) 
		{
			var distance = (player.transform.position - this.transform.position).sqrMagnitude;
			if (distance <= 15)
			{
				bone.addBone();
				this.gameObject.SetActive(false);
                draw.drawLines();
			}
		}
	}
}
