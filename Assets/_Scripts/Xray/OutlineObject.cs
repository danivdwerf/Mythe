using UnityEngine;
using System.Collections;

public class OutlineObject : MonoBehaviour 
{
	[Range(0, 0.1f)][SerializeField]private float lineWidth;
	private Renderer renderer;
	private Shader originalShader;
	private SwitchMaterial materialSwitch;

	void Awake () 
	{
		renderer = GetComponent<Renderer> ();
		originalShader = this.renderer.material.shader;
		materialSwitch = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SwitchMaterial> ();
	}

	public void normalMat()
	{
		materialSwitch.normalMaterial (this.renderer, this.originalShader);
		return;
	}

	public void visionMat()
	{
		materialSwitch.outlineMaterial (this.renderer, this.lineWidth);
		return;
	}
}
