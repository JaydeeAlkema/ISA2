using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviourPunCallbacks
{
	#region Variables
	[SerializeField] private TextMeshProUGUI text = default;        // Reference to the TextMeshProUGUI Component on the object.
	[SerializeField] private Player player;

	private bool ready = false;
	#endregion

	#region properties
	public Player Player { get => player; private set => player = value; }
	public bool Ready { get => ready; set => ready = value; }
	#endregion

	#region Functions
	public void SetPlayerInfo(Player _player)
	{
		player = _player;
		SetPlayerText(player);
	}

	private void SetPlayerText(Player player)
	{
		text.text = player.NickName;
	}
	#endregion
}
