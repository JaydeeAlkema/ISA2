using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviour
{
	#region Variables
	[SerializeField] private TextMeshProUGUI text = default;        // Reference to the TextMeshProUGUI Component on the object.
	[SerializeField] private Player player;
	#endregion

	#region properties
	public Player Player { get => player; private set => player = value; }
	#endregion

	#region Functions
	public void SetPlayerInfo(Player _player)

	{
		player = _player;
		text.text = player.NickName;
	}
	#endregion
}
