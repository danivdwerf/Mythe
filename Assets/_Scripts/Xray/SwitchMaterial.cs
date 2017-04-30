using UnityEngine;
using System.Collections;

public class SwitchMaterial : MonoBehaviour 
{
	//private Shader normalShader;
	[SerializeField] private Shader outlineShader;
	public void outlineMaterial(Renderer renderer, float lineWidth)
	{
		renderer.material.shader = outlineShader;
		renderer.material.SetFloat ("_Outline", lineWidth);
		renderer.material.SetColor ("_Color", Color.white);
		renderer.material.SetColor ("_OutlineColor", Color.red);
	}

	public void normalMaterial(Renderer renderer, Shader normalShader)
	{
		renderer.material.shader = normalShader;
	}
}
