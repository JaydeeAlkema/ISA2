using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
	#region Variables
	[SerializeField] private GameObject prefab;
	#endregion

	#region Monobehaviour Callbacks
	private void Awake()
	{
		Vector2 offset = Random.insideUnitCircle * 10f;
		Vector3 pos = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);

		MasterManager.NetworkInstantiate(prefab, pos, Quaternion.identity);
	}
	#endregion
}
