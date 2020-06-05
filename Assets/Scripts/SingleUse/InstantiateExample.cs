using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
	#region Variables
	[SerializeField] private GameObject prefab;
	#endregion

	#region Monobehaviour Callbacks
	private void Awake()
	{
		MasterManager.NetworkInstantiate(prefab, transform.position, Quaternion.identity);
	}
	#endregion
}
