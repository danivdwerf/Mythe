using System.Collections.Generic;

using UnityEngine;

public class DrawLineToBones : MonoBehaviour 
{
	[SerializeField]private Material lineMaterial;
	[SerializeField]private float lineWidth;
	[SerializeField]private float lineOffsetY;
	private List<LineRenderer> lineRenderers;
	private ObjectPooler bonePool;

	private void Start()
	{
		bonePool = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ObjectPooler>();
		lineRenderers = new List<LineRenderer> ();
		for (int i = 0; i < bonePool.PoolSize; i++)
		{
			addlineRenderer(bonePool.Pool[i]);
		}
	}

	public void addToList(GameObject bone)
	{
		addlineRenderer (bone);
	}

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

	public void drawLines()
	{
		//print (bonePool.PoolSize);
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
