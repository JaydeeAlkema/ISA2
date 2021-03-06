﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
	#region Variables
	[SerializeField] private Transform content = default;                   // Content where the room listings are added to.
	[SerializeField] private RoomListing roomListing = default;             // Prefab gameobject of the room listig object.
	[SerializeField] private List<RoomListing> listings = new List<RoomListing>();
	[SerializeField] private RoomsCanvases roomsCanvases = default;
	#endregion

	#region Functions
	public void FirstInitialize(RoomsCanvases canvases)
	{
		roomsCanvases = canvases;
	}

	public override void OnJoinedRoom()
	{
		roomsCanvases.CurrentRoomCanvas.Show();
		content.DestroyChildren();
		listings.Clear();
	}

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		foreach(RoomInfo info in roomList)
		{
			// Removed from rooms list
			if(info.RemovedFromList)
			{
				int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
				if(index != -1)
				{
					Destroy(listings[index].gameObject);
					listings.RemoveAt(index);
				}
			}
			// Added from rooms list
			else
			{
				int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
				if(index == -1)
				{
					RoomListing listing = Instantiate(roomListing, content);
					if(listing != null)
					{
						listing.SetRoomInfo(info);
						listings.Add(listing);
					}
				}
			}
		}
	}
	#endregion
}
