using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
	#region Variables
	[SerializeField] private Transform content = default;                               // Content where the Player Listings are added to.
	[SerializeField] private PlayerListing playerListing = default;                     // Prefab gameobject of the Player Listing object.
	[SerializeField] private List<PlayerListing> listings = new List<PlayerListing>();

	private RoomsCanvases roomsCanvases = default;
	#endregion

	#region Functions
	public override void OnEnable()
	{
		base.OnEnable();
		GetCurrentRoomPlayers();
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

	public void OnClick_StartGame()
	{
		if(PhotonNetwork.IsMasterClient)
			PhotonNetwork.LoadLevel(1);
	}
	#endregion
}
