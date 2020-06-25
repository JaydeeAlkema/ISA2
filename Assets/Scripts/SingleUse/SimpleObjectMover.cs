using Photon.Pun;
using UnityEngine;

public class SimpleObjectMover : MonoBehaviourPun, IPunObservable
{
	[SerializeField] private float movespeed = 1f;
	private Animator anim;

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

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if(base.photonView.IsMine)
		{
			float x = Input.GetAxisRaw("Horizontal");
			float y = Input.GetAxisRaw("Vertical");
			Vector3 finalMoveSpeed = new Vector3(x, y, 0f).normalized * movespeed;

			transform.position += finalMoveSpeed * Time.deltaTime;

			UpdateMovingBoolean((x != 0f || y != 0f));
		}
	}

	private void UpdateMovingBoolean(bool moving)
	{
		anim.SetBool("Moving", moving);
	}

}
