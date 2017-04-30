using System.Collections.Generic;

using UnityEngine;

public class Bones : MonoBehaviour 
{
	[SerializeField]private GameObject bonePrefab;
	[SerializeField]private float maxBones;
	[SerializeField]private Material lineMaterial;
	[SerializeField]private float lineWidth;
	[SerializeField]private float lineOffsetY;
	private int playerBones;
	public int AmountBones{get{return playerBones;}}
	private List<GameObject> bones;
	private List<LineRenderer> lineRenderers;

	private void Start()
	{
		bones = new List<GameObject> ();
		playerBones = 10;
		for (var i = 0; i < maxBones; i++)
		{
			var bone = Instantiate (bonePrefab) as GameObject;
			bone.name = "bone" + i;
			bone.transform.position = Vector3.zero;
			bone.transform.eulerAngles = new Vector3 (0, 0, 0);
			bone.SetActive (false);
			bones.Add (bone);
		}

		lineRenderers = new List<LineRenderer> ();
		for (int i = 0; i < bones.Count; i++)
		{
			lineRenderers.Add (bones [i].AddComponent<LineRenderer> ());
			lineRenderers[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			lineRenderers[i].receiveShadows = false;
			lineRenderers[i].enabled = false;
			lineRenderers[i].material = lineMaterial; 
			lineRenderers[i].startWidth = lineWidth;
			lineRenderers[i].endWidth = lineWidth;
		}
	}

	public GameObject getLastBone()
	{
		for (var i = 0; i < bones.Count; i++)
		{
			if (!bones [i].gameObject.activeInHierarchy)
			{
				playerBones--;
				return bones [i];
			}
		}
		return null;
	}

	private void Update()
	{
		/*
		if (Input.GetButtonDown (Controller.Triangle))
		{
			bones [3].SetActive (false);
			drawLines ();
		}
		*/
	}

	public void drawLines()
	{
		for (var i = 0; i < bones.Count; i++)
		{
			if (i == 0)
				continue;
			
			if (!bones[i].activeInHierarchy)
				continue;

			if (i == 1)
			{
				lineRenderers [0].SetPosition (0, bones [0].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [0].SetPosition (1, bones [1].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [0].enabled = true;

				lineRenderers [1].SetPosition (0, bones [1].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [1].SetPosition (1, bones [0].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [1].enabled = true;
				continue;
			}
			
			for (var j = i-1; j > 0; j--)
			{
				if (!bones [j].activeInHierarchy)
					break;

				lineRenderers [j].SetPosition (0, bones [j].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [j].SetPosition (1, bones [i].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [j].enabled = true;

				lineRenderers [i].SetPosition (0, bones [i].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [i].SetPosition (1, bones [0].transform.position + new Vector3 (0, lineOffsetY, 0));
				lineRenderers [i].enabled = true;
				break;
			}
		}
	}
}
