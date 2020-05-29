using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
	#region Variables
	[SerializeField] private TextMeshProUGUI text = default;        // Reference to the TextMeshProUGUI Component on the object.
	#endregion

	#region properties
	public RoomInfo RoomInfo { get; private set; }
	#endregion

	#region Functions
	public void SetRoomInfo(RoomInfo roomInfo)
	{
		RoomInfo = roomInfo;
		text.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
	}

	public void OnClickButton()
	{
		PhotonNetwork.JoinRoom(RoomInfo.Name);
	}
	#endregion
}
