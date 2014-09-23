using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	float Speed = 1000.0f;
	
	void Start()
	{
	
	}
	
	void Update()
	{
		rigidbody2D.AddRelativeForce(Vector3.up * Speed * Time.fixedDeltaTime); 
		//rigidbody.velocity = 
	}
}
