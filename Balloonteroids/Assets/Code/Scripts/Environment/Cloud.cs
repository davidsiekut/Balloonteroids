using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
	public Sprite[] Sprites;
	float speed;
	
	void Start()
	{
		int s = UnityEngine.Random.Range(0, 3);
		(renderer as SpriteRenderer).sprite = Sprites[s];
	
		float r = UnityEngine.Random.Range(0.0f, 1.0f);
		transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, r, 0.5f));
		speed = UnityEngine.Random.Range(0.0f, 1.0f);
	}
	
	void Update()
	{
		transform.Translate(-Vector3.right * speed * Time.deltaTime);
		if (Camera.main.WorldToViewportPoint(transform.position).x < 0)
		{
			Destroy(gameObject);
		}
	}
}
