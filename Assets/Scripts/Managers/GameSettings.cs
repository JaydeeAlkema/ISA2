using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
	#region Variables
	[SerializeField] private string defaultNickname = "Anonymous ";   // The default nickname when no name is entered
	[SerializeField] private string gameVersion = "0.0.5.0";  // Build version of the game
	#endregion

	#region Properties
	public string DefaultNickname { get => defaultNickname + Random.Range(0, int.MaxValue); set => defaultNickname = value; }
	public string GameVersion { get => gameVersion; }
	#endregion
}