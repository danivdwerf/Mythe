using System.Collections.Generic;

using UnityEngine;

public class Bones : MonoBehaviour 
{
	[SerializeField]private GameObject bonePrefab;
	[SerializeField]private float maxBones;
	[SerializeField]private Material lineMaterial;
	[SerializeField]private float lineWidth;
	[SerializeField]private float lineOffsetY;

	private List<GameObject> bones;
	private List<LineRenderer> lineRenderers;

	private void Start()
	{
		bones = new List<GameObject> ();
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
				return bones [i];
		}
		return null;
	}

	public void drawLines()
	{
		for (var i = 0; i < bones.Count; i++)
		{
			if (i == 0)
				continue;
			
			if (!bones[i].activeInHierarchy)
				continue;

			lineRenderers[(i-1)].SetPosition (0, bones[(i-1)].transform.position + new Vector3(0, lineOffsetY, 0));
			lineRenderers[(i-1)].SetPosition (1, bones[i].transform.position + new Vector3(0, lineOffsetY, 0));
			lineRenderers [(i - 1)].enabled = true;

			lineRenderers[i].SetPosition (0, bones[i].transform.position + new Vector3(0, lineOffsetY, 0));
			lineRenderers[i].SetPosition (1, bones[0].transform.position + new Vector3(0, lineOffsetY, 0));
			lineRenderers [i].enabled = true;
		}
	}
}
