using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour
{
	public float TTL = 1.0f;

	void Start()
	{
	
	}
	
	void Update()
	{
		TTL -= Time.deltaTime;
		if (TTL < 0)
			Destroy(gameObject);
	}
}
