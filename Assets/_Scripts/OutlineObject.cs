using UnityEngine;
using System.Collections;

public class OutlineObject : MonoBehaviour 
{
	[Range(0, 0.1f)][SerializeField]private float lineWidth;
	private Renderer renderer;
	private SwitchMaterial materialSwitch;
	private bool isOutlined;

	void Start () 
	{
		isOutlined = false;
		renderer = GetComponent<Renderer> ();
		materialSwitch = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SwitchMaterial> ();
	}

	public void switchMat()
	{
		if(this.isOutlined)
		{
			materialSwitch.normalMaterial (this.renderer);
			this.isOutlined = false;
			return;
		}
		materialSwitch.outlineMaterial (this.renderer, this.lineWidth);
		this.isOutlined = true;
		return;
	}
}
