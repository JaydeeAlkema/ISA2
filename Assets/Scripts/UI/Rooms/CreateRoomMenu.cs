using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
	#region Variables
	[SerializeField] TMP_InputField roomName = default;            // The name of the Room.

	private RoomsCanvases roomsCanvases = default;         // Reference to the RoomsCanvases class.
	#endregion

	#region Properties

	#endregion

	#region Functions
	public void FirstInitialize(RoomsCanvases _roomsCanvases)
	{
		roomsCanvases = _roomsCanvases;
	}

	/// <summary>
	/// Creates a room. If the names exists you will join the room instead of creating it.
	/// Room name cant be empty or shorter than 6 characters.
	/// </summary>
	public void OnClick_CreateRoom()
	{
		if(!PhotonNetwork.IsConnected) return;

		RoomOptions roomOptions = new RoomOptions
		{
			MaxPlayers = 2
		};

		if(roomName.text != "" || roomName.text.Length > 4)
		{
			PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
		}
	}

	public override void OnCreatedRoom()
	{
		Debug.Log("Created Room Succesfully!", this);
		roomsCanvases.CurrentRoomCanvas.Show();
	}

	public override void OnCreateRoomFailed(short returnCode, string message)
	{
		Debug.Log("Room Creation Failed: " + message, this);
	}
	#endregion
}
