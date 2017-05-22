using System.Collections;
using UnityEngine;

/// <summary>
/// Dark area.
/// </summary>
public class DarkArea : MonoBehaviour 
{
    /// <summary>
    /// The player.
    /// </summary>
	private GameObject player;
    /// <summary>
    /// The sprite.
    /// </summary>
	private SpriteRenderer sprite;
    /// <summary>
    /// Boolean if player is in area.
    /// </summary>
	private bool inArea;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		sprite = player.GetComponentInChildren<SpriteRenderer> ();
		sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, 0);
		inArea = false;
	}

    /// <summary>
    /// Raises the trigger enter event.
    /// </summary>
    /// <param name="other">Other.</param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != player)
			return;
		inArea = true;
		StartCoroutine ("darkenScreen");
	}

    /// <summary>
    /// Raises the trigger exit event.
    /// </summary>
    /// <param name="other">Other.</param>
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != player)
			return;
		
		inArea = false;
		StopCoroutine ("darkenScreen");
		sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, 0);
	}

    /// <summary>
    /// Darkens the screen.
    /// </summary>
    /// <returns>The screen.</returns>
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
