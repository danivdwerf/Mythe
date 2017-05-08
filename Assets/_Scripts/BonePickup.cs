using UnityEngine;

public class BonePickup : MonoBehaviour 
{
	private Transform player;
	private SpawnBone bone;
    private DrawLineToBones draw;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		bone = FindObjectOfType<SpawnBone>();
        draw = FindObjectOfType<DrawLineToBones>();
	}

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
