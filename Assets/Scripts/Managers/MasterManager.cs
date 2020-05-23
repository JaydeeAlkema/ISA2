using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
	#region Variables
	[SerializeField] private GameSettings gameSettings = default;
	#endregion

	#region Properties
	public static GameSettings GameSettings { get => Instance.gameSettings; }
	#endregion
}
