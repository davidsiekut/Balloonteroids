using UnityEngine;
using System.Collections;

namespace Balloonteroids.Code.Scripts.BalloonCluster
{
	public class Controller : MonoBehaviour
	{
		float Acceleration = 10.0f;
		float MaxSpeed = 1.0f;
		
		void Start()
		{
			transform.Rotate(Vector3.forward, UnityEngine.Random.Range(1, 360));
		}
		
		void FixedUpdate()
		{		
			rigidbody2D.AddRelativeForce(Vector3.up * Acceleration * Time.fixedDeltaTime);
			
			if (rigidbody2D.velocity.x > MaxSpeed)
			{
				Vector2 v = rigidbody2D.velocity;
				v.x = MaxSpeed;
				rigidbody2D.velocity = v;
			}
			if (rigidbody2D.velocity.y > MaxSpeed)
			{
				Vector2 v = rigidbody2D.velocity;
				v.y = MaxSpeed;
				rigidbody2D.velocity = v;
			}
		}
	}
}