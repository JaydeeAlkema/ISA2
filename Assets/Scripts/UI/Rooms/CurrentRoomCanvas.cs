using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
	#region Variables
	private RoomsCanvases roomsCanvases = default;         // Reference to the RoomsCanvases class.s
	#endregion

	#region Functions
	public void FirstInitialize(RoomsCanvases _roomsCanvases)
	{
		roomsCanvases = _roomsCanvases;
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	private void Hide()
	{
		gameObject.SetActive(false);
	}
	#endregion
}
