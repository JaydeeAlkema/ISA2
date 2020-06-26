using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
	#region Variables
	[SerializeField] private GameSettings gameSettings = default;
	[SerializeField] private List<NetworkedPrefab> networkedPrefabs = new List<NetworkedPrefab>();
	#endregion

	#region Properties
	public static GameSettings GameSettings { get => Instance.gameSettings; set => Instance.gameSettings = value; }
	#endregion

	#region Functions
	public static GameObject NetworkInstantiate(GameObject obj, Vector3 pos, Quaternion rot)
	{
		foreach(NetworkedPrefab entry in Instance.networkedPrefabs)
		{
			if(entry.Prefab == obj)
			{
				if(entry.Path != string.Empty)
				{
					GameObject result = PhotonNetwork.Instantiate(entry.Path, pos, rot);
					return result;
				}
				else
				{
					Debug.LogError("Path is empty for GameObject Name " + entry.Prefab.name);
					return null;
				}
			}
		}
		return null;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void PopulateNetworkedPrefabs()
	{
#if UNITY_EDITOR
		Instance.networkedPrefabs.Clear();

		GameObject[] results = Resources.LoadAll<GameObject>("");
		for(int i = 0; i < results.Length; i++)
		{
			if(results[i].GetComponent<PhotonView>() != null)
			{
				string path = AssetDatabase.GetAssetPath(results[i]);
				Instance.networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
			}
		}
#endif
	}
	#endregion
}
