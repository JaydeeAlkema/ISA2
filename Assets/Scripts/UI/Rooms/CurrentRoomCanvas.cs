using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
	#region Variables
	[SerializeField] private PlayerListingsMenu playerListingsMenu = default;
	[SerializeField] private LeaveRoomMenu leaveRoomMenu = default;

	private RoomsCanvases roomsCanvases = default;         // Reference to the RoomsCanvases class.s
	#endregion

	#region Functions
	public void FirstInitialize(RoomsCanvases _roomsCanvases)
	{
		roomsCanvases = _roomsCanvases;
		playerListingsMenu.FirstInitialize(_roomsCanvases);
		leaveRoomMenu.FirstInitialize(_roomsCanvases);
	}


	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	#endregion
}
