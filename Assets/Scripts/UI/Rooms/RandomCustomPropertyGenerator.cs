using Photon.Pun;
using TMPro;
using UnityEngine;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
	#region Variables
	[SerializeField] private TextMeshProUGUI text = default;
	private ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
	#endregion

	private void SetCustomNumber()
	{
		System.Random rnd = new System.Random();
		int result = rnd.Next(0, 99);

		text.text = result.ToString();

		customProperties["RandomNumber"] = result;
		PhotonNetwork.SetPlayerCustomProperties(customProperties);
		//PhotonNetwork.LocalPlayer.CustomProperties = customProperties;
	}

	public void OnClick_Button()
	{
		SetCustomNumber();
	}
}
