using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Draw line to bones.
/// </summary>
public class DrawLineToBones : MonoBehaviour 
{
    /// <summary>
    /// The line material.
    /// </summary>
	[SerializeField]private Material lineMaterial;
    /// <summary>
    /// The width of the line.
    /// </summary>
	[SerializeField]private float lineWidth;
    /// <summary>
    /// The line offset y.
    /// </summary>
	[SerializeField]private float lineOffsetY;
    /// <summary>
    /// The line renderers.
    /// </summary>
	private List<LineRenderer> lineRenderers;
    /// <summary>
    /// Reference to ObjectPooler.
    /// </summary>
	private ObjectPooler bonePool;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		bonePool = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ObjectPooler>();
		lineRenderers = new List<LineRenderer> ();
		for (int i = 0; i < bonePool.PoolSize; i++)
		{
			addlineRenderer(bonePool.Pool[i]);
		}
	}

    /// <summary>
    /// Adds renderer to list.
    /// </summary>
    /// <param name="bone">Bone.</param>
	public void addToList(GameObject bone)
	{
		addlineRenderer (bone);
	}

    /// <summary>
    /// Adds linerenderer to bone and puts is in the list.
    /// </summary>
    /// <param name="bone">Bone.</param>
	private void addlineRenderer(GameObject bone)
	{
		var line = bone.AddComponent<LineRenderer> ();
		line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		line.receiveShadows = false;
		line.enabled = false;
		line.material = lineMaterial; 
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
		lineRenderers.Add (line);
	}

    /// <summary>
    /// Draws the lines.
    /// </summary>
	public void drawLines()
	{
		for (var i = 0; i < bonePool.PoolSize; i++)
		{
			if (i == 0)
				continue;
			
			if (!bonePool.Pool[i].activeInHierarchy)
				continue;

			if (i == 1)
			{
				lineRenderers [0].SetPosition (0, bonePool.Pool [0].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [0].SetPosition (1, bonePool.Pool [1].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [0].enabled = true;

				lineRenderers [1].SetPosition (0, bonePool.Pool [1].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [1].SetPosition (1, bonePool.Pool [0].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [1].enabled = true;
				continue;
			} 

			for (var j = i-1; j > 0; j--)
			{
				if (!bonePool.Pool [j].activeInHierarchy)
					break;

				lineRenderers [j].SetPosition (0, bonePool.Pool [j].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [j].SetPosition (1, bonePool.Pool [i].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [j].enabled = true;

				lineRenderers [i].SetPosition (0, bonePool.Pool [i].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [i].SetPosition (1, bonePool.Pool [0].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [i].enabled = true;
				break;
			}
		}
	}
}
