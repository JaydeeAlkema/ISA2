using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
	#region Variables
	[SerializeField] private Transform content = default;                               // Content where the Player Listings are added to.
	[SerializeField] private PlayerListing playerListing = default;                     // Prefab gameobject of the Player Listing object.
	[SerializeField] private List<PlayerListing> listings = new List<PlayerListing>();
	[SerializeField] private Toggle readyUpToggle = default;

	private bool ready = false;
	private RoomsCanvases roomsCanvases = default;
	#endregion

	#region Functions
	public override void OnEnable()
	{
		base.OnEnable();
		GetCurrentRoomPlayers();
		SetReadyUp(false);
	}

	public override void OnDisable()
	{
		base.OnDisable();
		for(int i = 0; i < listings.Count; i++)
		{
			Destroy(listings[i].gameObject);
		}

		listings.Clear();
	}

	public void FirstInitialize(RoomsCanvases _roomsCanvases)
	{
		roomsCanvases = _roomsCanvases;
	}

	private void SetReadyUp(bool state)
	{
		ready = state;
		readyUpToggle.isOn = ready;
	}

	private void GetCurrentRoomPlayers()
	{
		if(!PhotonNetwork.IsConnected)
			return;

		if(PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
			return;

		foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
		{
			AddPlayerListing(playerInfo.Value);
		}
	}

	private void AddPlayerListing(Player _player)
	{
		int index = listings.FindIndex(x => x.Player == _player);
		if(index != -1)
		{
			listings[index].SetPlayerInfo(_player);
		}
		else
		{
			PlayerListing listing = Instantiate(playerListing, content);
			if(listing != null)
			{
				listing.SetPlayerInfo(_player);
				listings.Add(listing);
			}
		}
	}

	public override void OnMasterClientSwitched(Player newMasterClient)
	{
		roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		AddPlayerListing(newPlayer);
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
		int index = listings.FindIndex(x => x.Player == otherPlayer);
		if(index != -1)
		{
			Destroy(listings[index].gameObject);
			listings.RemoveAt(index);
		}
	}

	public void OnClick_StartGame()
	{
		if(PhotonNetwork.IsMasterClient)
		{
			for(int i = 0; i < listings.Count; i++)
			{
				if(listings[i].Player != PhotonNetwork.LocalPlayer)
				{
					if(!listings[i].Ready) return;
				}
			}

			PhotonNetwork.CurrentRoom.IsOpen = false;
			PhotonNetwork.CurrentRoom.IsVisible = false;
			PhotonNetwork.LoadLevel(1);
		}
	}

	public void OnClick_ReadyUp()
	{
		if(!PhotonNetwork.IsMasterClient)
		{
			SetReadyUp(!ready);
			base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, ready);
		}
	}

	[PunRPC]
	private void RPC_ChangeReadyState(Player player, bool ready)
	{
		int index = listings.FindIndex(x => x.Player == player);
		if(index != -1)
			listings[index].Ready = ready;
	}
	#endregion
}
