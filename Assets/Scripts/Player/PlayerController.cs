using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPun, IDamageable
{
	[SerializeField] private Transform bodySprite = default;        // Reference to the body sprite. This will be the part that rotates.
	[SerializeField] private float health = 100f;                   // How much health the player has.
	[SerializeField] private float movespeed = 1f;                  // Movement speed...
	[Space]
	[SerializeField] private Transform firePoint = default;         // Transform point from which we fire .
	[SerializeField] private string shootInputString = "Fire1";     // Which input to check for to fire your weapon.
	[SerializeField] private LayerMask hitLayer = default;          // Which layers 
	[Space]
	[SerializeField] private Vector3 respawnPos = default;          // Respawn position.

	SpriteRenderer spriteRenderer = default;

	private void OnEnable()
	{
		gameObject.name = PhotonNetwork.LocalPlayer.NickName;
		respawnPos = transform.position;
		spriteRenderer = bodySprite.GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if(base.photonView.IsMine)
		{
			Movement();
			RotateTowardsMouse();

			// Listen for shoot input to be able to shoot.
			if(Input.GetButtonDown(shootInputString)) Shoot();
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

	/// <summary>
	/// Fires a ray towards the direction the player is facing.
	/// Then does some stuff when hitting stuff...
	/// </summary>
	private void Shoot()
	{
		RaycastHit2D hit;
		hit = Physics2D.Raycast(firePoint.position, bodySprite.transform.up, 1000f, hitLayer);

		if(hit)
		{
			Debug.Log("We hit: " + hit.collider.name);
			Debug.DrawLine(firePoint.position, hit.point, Color.green, 0.1f);

			if(hit.collider.name != gameObject.name)
			{
				hit.collider.GetComponent<IDamageable>()?.Damage(25f);
			}
		}
		else
		{
			Debug.Log("We hit Nothing!");
			Debug.DrawLine(firePoint.position, bodySprite.transform.up * 1000f, Color.red, 0.1f);
		}
	}

	/// <summary>
	/// IDamageable interface Damage method implementation.
	/// </summary>
	/// <param name="value"></param>
	public void Damage(float value)
	{
		StartCoroutine(OnHitAnimation());
		health -= value;

		if(health <= 0)
		{
			Respawn();
		}
	}

	/// <summary>
	/// Respawns the player to its respawn point.
	/// </summary>
	private void Respawn()
	{
		transform.localPosition = Vector3.zero + respawnPos;
		health = 100;
	}

	/// <summary>
	/// A very simple on hit "animation".
	/// </summary>
	/// <returns></returns>
	private IEnumerator OnHitAnimation()
	{
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.15f);
		spriteRenderer.color = Color.white;
	}
}
