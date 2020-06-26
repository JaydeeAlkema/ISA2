using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/// <summary>
/// A very simple class that tests if a connection can be made.
/// </summary>
public class TestConnection : MonoBehaviourPunCallbacks
{
	#region Monobehaviour Callbacks
	private void Start()
	{
		Debug.Log("Connecting to Server...");
		PhotonNetwork.AutomaticallySyncScene = true;
		PhotonNetwork.NickName = MasterManager.GameSettings.DefaultNickname;
		PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
		PhotonNetwork.ConnectUsingSettings();
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Server!");
		Debug.Log("Player [" + PhotonNetwork.LocalPlayer.NickName + "] Connected to the Server.");

		if(!PhotonNetwork.InLobby)
			PhotonNetwork.JoinLobby();
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
		Debug.LogWarning("Disconnected from server for reason: " + cause.ToString());
	}
	#endregion
}
