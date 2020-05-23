using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
	#region Variables
	[SerializeField] private string nickName = "DevJaydee";
	[SerializeField] private string gameVersion = "0.0.0";
	#endregion

	#region Properties
	public string NickName { get => nickName + Random.Range(0, int.MaxValue).ToString(); }
	public string GameVersion { get => gameVersion; }
	#endregion
}