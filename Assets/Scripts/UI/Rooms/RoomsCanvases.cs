using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
	#region Variables
	[SerializeField] private CreateOrJoinRoomCanvas createOrJoinRoomCanvas = default;
	[SerializeField] private CurrentRoomCanvas currentRoomCanvas = default;
	#endregion

	#region Properties
	public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas { get => createOrJoinRoomCanvas; }
	public CurrentRoomCanvas CurrentRoomCanvas { get => currentRoomCanvas; }
	#endregion

	#region Monobehaviour Callbacks
	private void Awake()
	{
		FirstInitialize();
	}
	#endregion

	#region Functions
	private void FirstInitialize()
	{
		CreateOrJoinRoomCanvas.FirstInitialize(this);
		CurrentRoomCanvas.FirstInitialize(this);
	}
	#endregion
}
