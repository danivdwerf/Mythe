using UnityEngine;
using System.Collections;
/// <summary>
/// Switch material.
/// </summary>
public class SwitchMaterial : MonoBehaviour 
{
    /// <summary>
    /// The outline shader.
    /// </summary>
	[SerializeField] private Shader outlineShader;
    /// <summary>
    /// Outlines the material.
    /// </summary>
    /// <param name="renderer">Renderer.</param>
    /// <param name="lineWidth">Line width.</param>

    private int outlineWidth;
    private int normalColour;
    private int outlineColour;

    private void Start()
    {
        outlineWidth = Shader.PropertyToID("_Outline");
        normalColour = Shader.PropertyToID("_Colour");
        outlineColour = Shader.PropertyToID("_OutlineColour");
    }

	public void outlineMaterial(Renderer renderer, float lineWidth)
	{
		renderer.material.shader = outlineShader;
        renderer.material.SetFloat (outlineWidth, lineWidth);
        renderer.material.SetColor (normalColour, Color.white);
        renderer.material.SetColor (outlineColour, Color.red);
	}

    /// <summary>
    /// Normals the material.
    /// </summary>
    /// <param name="renderer">Renderer.</param>
    /// <param name="normalShader">Normal shader.</param>
	public void normalMaterial(Renderer renderer, Shader normalShader)
	{
		renderer.material.shader = normalShader;
	}
}
