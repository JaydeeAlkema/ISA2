using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMover : MonoBehaviourPun
{
	[SerializeField] private float movespeed = 1f;
	private Animator anim;

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
