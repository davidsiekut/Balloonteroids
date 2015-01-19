using UnityEngine;
using System.Collections;

public class WaterBalloon : MonoBehaviour
{
	Vector2 direction;
	float speed = 50.0f;
	
	void Start()
	{
	
	}
	
	void Update()
	{
		rigidbody2D.AddRelativeForce(direction * speed * Time.fixedDeltaTime);
	}
	
	public void SetDirection(Vector2 v)
	{
		direction = v;
	}
}
