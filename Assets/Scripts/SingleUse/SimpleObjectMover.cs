using Photon.Pun;
using UnityEngine;

public class SimpleObjectMover : MonoBehaviourPun, IPunObservable
{
	[SerializeField] private float movespeed = 1f;

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.IsWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else if(stream.IsReading)
		{
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation = (Quaternion)stream.ReceiveNext();
		}
	}

	private void Update()
	{
		if(base.photonView.IsMine)
		{
			Movement();
			RotateTowardsMouse();
		}
	}

	private void Movement()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector3 finalMoveSpeed = new Vector3(x, y, 0f).normalized * movespeed;

		transform.position += finalMoveSpeed * Time.deltaTime;
	}

	private void RotateTowardsMouse()
	{
		//rotation
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0;

		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
	}
}
