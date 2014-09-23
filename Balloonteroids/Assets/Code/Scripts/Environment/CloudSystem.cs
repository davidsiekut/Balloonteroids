using UnityEngine;
using System.Collections;

public class CloudSystem : MonoBehaviour
{
	public GameObject Cloud;
	public float TimeToCloudMin;
	public float TimeToCloudMax;
	float timeToCloud;

	void Start()
	{
		timeToCloud = UnityEngine.Random.Range(TimeToCloudMin, TimeToCloudMax);
	}
	
	void Update()
	{
		timeToCloud -= Time.deltaTime;
		if (timeToCloud < 0)
		{
			timeToCloud = UnityEngine.Random.Range(TimeToCloudMin, TimeToCloudMax);
			spawnCloud();
		}
	}
	
	void spawnCloud()
	{
		GameObject g = GameObject.Instantiate(Cloud) as GameObject;
		g.transform.parent = transform;
	}
}
