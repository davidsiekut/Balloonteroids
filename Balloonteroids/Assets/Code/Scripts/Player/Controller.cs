using UnityEngine;
using System.Collections;

namespace Balloonteroids.Code.Scripts.Player
{
	public class Controller : MonoBehaviour
	{
		public float Acceleration = 0.0f;
		public float MaxSpeed = 10.0f;
		public float TurnSpeed = 0.0f;
	
		void Start()
		{
		
		}
		
		void FixedUpdate()
		{
			transform.Rotate(-Vector3.forward * Input.GetAxis("Horizontal") * TurnSpeed * Time.fixedDeltaTime); 
						
			if(Input.GetAxis("Vertical") > 0)
			{
				rigidbody2D.AddRelativeForce(Vector3.up * Acceleration * Time.fixedDeltaTime); 
			}
		}
	}
}