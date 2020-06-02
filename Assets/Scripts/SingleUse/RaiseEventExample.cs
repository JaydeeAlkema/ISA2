using UnityEngine;

public class RaiseEventExample : MonoBehaviour
{
	private SpriteRenderer spriteRenderer = default;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ChangeColor();
		}
	}

	private void ChangeColor()
	{
		float r = Random.Range(0f, 1f);
		float g = Random.Range(0f, 1f);
		float b = Random.Range(0f, 1f);

		spriteRenderer.color = new Color(r, g, b, 1f);
	}
}
