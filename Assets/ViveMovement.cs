using UnityEngine;

public class NewBehaviourScript : MonoBehaviour 
{
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller{ get{return SteamVR_Controller.Input((int)trackedObj.index);}}
	[SerializeField]private GameObject player;
	private Rigidbody rigid;

	private void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		rigid = player.GetComponent<Rigidbody> ();
	}

	private void Start()
	{
		if (Controller.GetTouchDown (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
		{
			var input = Controller.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0).normalized;
			var position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);

			print (input);
			if(input.y > 0.5f && input.x >= -0.5f && input.x <= 0.5f)
			{
				rigid.MovePosition (position + Camera.main.transform.forward * Time.deltaTime);
			}

			if (input.y < -0.5f && input.x >= -0.5f && input.x <= 0.5f)
			{
				rigid.MovePosition (position + -Camera.main.transform.forward * Time.deltaTime);
			}

			if(input.x < -0.5f && input.y > -0.5f && input.y <= 0.5f)
			{
				rigid.MovePosition (position + Camera.main.transform.right * Time.deltaTime);
			}

			if (input.x > -0.5f && input.y >= -0.5f && input.y <= 0.5f)
			{
				rigid.MovePosition (position + -Camera.main.transform.right * Time.deltaTime);
			}
		}
	}
}
