using UnityEngine;
using System.Collections;

public class OutlineObject : MonoBehaviour {
	[Range(0, 0.1f)][SerializeField]private float lineWidth;
	private Renderer renderer;
	private SwitchMaterial materialSwitch;

	private bool isOutlined;

	// Use this for initialization
	void Start () {
		isOutlined = false;
		renderer = GetComponent<Renderer> ();

		materialSwitch = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SwitchMaterial> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void switchMat()
	{
		if(this.isOutlined){
			materialSwitch.normalMaterial (this.renderer);
			this.isOutlined = false;
			return;
		}
		materialSwitch.outlineMaterial (this.renderer, this.lineWidth);
		this.isOutlined = true;
		return;
	}
}
