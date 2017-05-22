using UnityEngine;
using System.Collections;
/// <summary>
/// Outline object.
/// </summary>
public class OutlineObject : MonoBehaviour
{
    /// <summary>
    /// The width of the line.
    /// </summary>
	[Range(0, 0.1f)][SerializeField]private float lineWidth;
    /// <summary>
    /// The renderer.
    /// </summary>
	private Renderer renderer;
    /// <summary>
    /// The original shader.
    /// </summary>
	private Shader originalShader;
    /// <summary>
    /// Reference to SwitchMaterial class.
    /// </summary>
	private SwitchMaterial materialSwitch;

    /// <summary>
    /// Awake this instance.
    /// </summary>
	private void Awake () 
	{
		renderer = GetComponent<Renderer> ();
		originalShader = this.renderer.material.shader;
		materialSwitch = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SwitchMaterial> ();
	}

    /// <summary>
    /// Set material to normal.
    /// </summary>
	public void normalMat()
	{
		materialSwitch.normalMaterial (this.renderer, this.originalShader);
		return;
	}

    /// <summary>
    /// Set material to vision.
    /// </summary>
	public void visionMat()
	{
		materialSwitch.outlineMaterial (this.renderer, this.lineWidth);
		return;
	}
}
