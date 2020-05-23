using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
	#region Variables
	[SerializeField] private CreateRoomMenu createRoomMenu = default;       // Reference to the CreateRoomMenu class.

	private RoomsCanvases roomsCanvases = default;         // Reference to the RoomsCanvases class.
	#endregion

	#region Functions
	public void FirstInitialize(RoomsCanvases _roomsCanvases)
	{
		roomsCanvases = _roomsCanvases;
		createRoomMenu.FirstInitialize(_roomsCanvases);
	}
	#endregion
}
