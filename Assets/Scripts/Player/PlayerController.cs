using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPun
{
	[SerializeField] private Transform bodySprite = default;        // Reference to the body sprite. This will be the part that rotates.
	[SerializeField] private float movespeed = 1f;                  // Movement speed...

	private void OnEnable()
	{
		gameObject.name = PhotonNetwork.LocalPlayer.NickName;
	}

	private void Update()
	{
		if(base.photonView.IsMine)
		{
			Movement();
			RotateTowardsMouse();
		}
	}

	/// <summary>
	/// Handles the movement input for the player and moves the object accordingly.
	/// </summary>
	private void Movement()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector3 finalMoveSpeed = new Vector3(x, y, 0f).normalized * movespeed;

		transform.position += finalMoveSpeed * Time.deltaTime;
	}

	/// <summary>
	/// Rotates the players towards the mouse position on the game window.
	/// </summary>
	private void RotateTowardsMouse()
	{
		//rotation
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0;

		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		bodySprite.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
	}
}
