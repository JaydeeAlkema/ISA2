using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkedPrefab
{
	#region Variables
	[SerializeField] private GameObject prefab = null;
	[SerializeField] private string path = null;
	#endregion

	#region Properties
	public GameObject Prefab { get => prefab; set => prefab = value; }
	public string Path { get => path; set => path = value; }
	#endregion

	#region Functions
	public NetworkedPrefab(GameObject _Prefab, string _Path)
	{
		prefab = _Prefab;
		path = ReturnPrefabPathModified(_Path);
	}

	private string ReturnPrefabPathModified(string path)
	{
		int extensionLength = System.IO.Path.GetExtension(path).Length;
		int additionalLength = 10;
		int startIndex = path.ToLower().IndexOf("resources");

		if(startIndex == -1)
			return string.Empty;
		else
			return path.Substring(startIndex + additionalLength, path.Length - (additionalLength + startIndex + extensionLength));
	}
	#endregion
}
