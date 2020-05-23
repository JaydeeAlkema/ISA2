using UnityEngine;

/// <summary>
/// The only purpose of this class is to make it so there is an instance of the master manager when building the game.
/// </summary>
public class SingletonReferences : MonoBehaviour
{
	[SerializeField] private MasterManager masterManager = default;			// Reference to the master manager.
}
