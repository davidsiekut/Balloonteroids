using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public AudioClip Shoot;
	float Speed = 1000.0f;

	void Start()
	{
		AudioSource.PlayClipAtPoint(Shoot, transform.position);
	}
	
	void Update()
	{
		rigidbody2D.AddRelativeForce(Vector3.up * Speed * Time.fixedDeltaTime); 
		//rigidbody.velocity = 
	}
}
