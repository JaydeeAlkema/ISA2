using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
	#region Variables
	[SerializeField] private CreateRoomMenu createRoomMenu = default;       // Reference to the CreateRoomMenu class.
	[SerializeField] private RoomListingsMenu roomListingsMenu = default;

	private RoomsCanvases roomsCanvases = default;         // Reference to the RoomsCanvases class.
	#endregion

	#region Functions
	public void FirstInitialize(RoomsCanvases _roomsCanvases)
	{
		roomsCanvases = _roomsCanvases;
		createRoomMenu.FirstInitialize(_roomsCanvases);

		roomListingsMenu.FirstInitialize(_roomsCanvases);
	}
	#endregion
}
