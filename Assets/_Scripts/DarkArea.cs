using System.Collections;
using UnityEngine;

public class DarkArea : MonoBehaviour 
{
	private GameObject player;
	private SpriteRenderer sprite;
	private bool inArea;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		sprite = player.GetComponentInChildren<SpriteRenderer> ();
		sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, 0);
		inArea = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != player)
			return;
		inArea = true;
		StartCoroutine ("darkenScreen");
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != player)
			return;
		
		inArea = false;
		StopCoroutine ("darkenScreen");
		sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, 0);
	}

	private IEnumerator darkenScreen()
	{
		while (inArea) 
		{
			var inputX = Input.GetAxisRaw (Controller.LeftStickX);
			var inputY = Input.GetAxisRaw (Controller.LeftStickY);
			if (Mathf.Abs((inputX + inputY)) > 0) 
			{
				if (sprite.color.a > 0.8f) 
				{
					yield return new WaitForSeconds (1);
					continue;
				}
				var alpha = sprite.color.a + 0.1f;
				sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, alpha);
			}
			yield return new WaitForSeconds (1);
		}
	}
}
